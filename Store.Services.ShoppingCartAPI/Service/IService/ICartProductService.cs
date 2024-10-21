using Store.Services.ShoppingCartAPI.Models.Dto;

namespace Store.Services.ShoppingCartAPI.Service.IService
{
    public interface ICartProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
