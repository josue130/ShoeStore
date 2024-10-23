using ShoeStore.Web.Models;

namespace ShoeStore.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetAllProductsAsync();
        Task<ResponseDto?> GetProductByIdAsync(Guid id);
        Task<ResponseDto?> CreateProductsAsync(ProductDto productDto);
        Task<ResponseDto?> UpdateProductsAsync(ProductDto productDto);
        Task<ResponseDto?> DeleteProductsAsync(Guid id);
    }
}
