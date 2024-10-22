using Store.Services.ShoppingCartAPI.Models.Dto;

namespace Store.Services.ShoppingCartAPI.Service.IService
{
    public interface ICartService
    {
        Task<CartDto> CartUpsert(CartDto cartDto);
        Task RemoveCart(Guid cartDetailId);
        Task<CartDto> GetCart(string userId);
    }
}
