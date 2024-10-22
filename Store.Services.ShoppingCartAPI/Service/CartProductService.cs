using Newtonsoft.Json;
using Store.Services.ShoppingCartAPI.Models.Dto;
using Store.Services.ShoppingCartAPI.Service.IService;

namespace Store.Services.ShoppingCartAPI.Service
{
    public class CartProductService : ICartProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CartProductService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
      

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Product");
            var response = await client.GetAsync($"/api/products");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(resp.Result));
            }
            return new List<ProductDto>();
        }
    }
}
