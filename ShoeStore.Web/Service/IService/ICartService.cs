using ShoeStore.Web.Models;

namespace ShoeStore.Web.Service.IService
{
    public interface ICartService
    {
        Task<ResponseDto>? GetCart(string userId);
        Task<ResponseDto>? UpsertCart(CartDto cartDto);
        Task<ResponseDto>? RemoveCart(Guid cartDetailsId);

    }
}
