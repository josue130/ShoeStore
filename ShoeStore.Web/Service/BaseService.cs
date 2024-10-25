using Newtonsoft.Json;
using ShoeStore.Web.Models;
using ShoeStore.Web.Service.IService;
using System.Net;
using System.Text;
using static ShoeStore.Web.Utility.SD;

namespace ShoeStore.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;
     
        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("ShoeStoreAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }



                message.RequestUri = new Uri(requestDto.Url);

                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponse = null;

                message.Method = requestDto.ApiType switch
                {
                    ApiType.POST => HttpMethod.Post,
                    ApiType.PUT => HttpMethod.Put,
                    ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get
                };
                
                apiResponse = await client.SendAsync(message);

                var apiResponseDto = apiResponse.StatusCode switch
                {
                    HttpStatusCode.NotFound => CreateErrorResponse("Not Found"),
                    HttpStatusCode.Forbidden => CreateErrorResponse("Access Denied"),
                    HttpStatusCode.Unauthorized => CreateErrorResponse("Unauthorized"),
                    HttpStatusCode.InternalServerError => CreateErrorResponse("Internal Server Error"),
                    _ => await HandleSuccessResponse(apiResponse)
                };
                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false
                };
                return dto;
            }
        }
        private ResponseDto CreateErrorResponse(string message) 
            => new() { IsSuccess = false, Message = message };

        private async Task<ResponseDto> HandleSuccessResponse(HttpResponseMessage apiResponse)
        {
            var apiContent = await apiResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseDto>(apiContent);
        }
    }
}
