using Store.Services.ProductAPI.Models;
using Store.Services.ProductAPI.Models.Dto;

namespace Store.Services.ProductAPI.Service.IService
{
    public interface IProductService
    {
        Task AddProduct(ProductDto productDto);
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(Guid productId);
        Task UpdateProduct(ProductDto productDto);
        Task DeleteProduct(Guid productId);
    }
}
