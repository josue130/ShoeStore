using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Services.ProductAPI.Data;
using Store.Services.ProductAPI.Models;
using Store.Services.ProductAPI.Models.Dto;
using Store.Services.ProductAPI.Service.IService;

namespace Store.Services.ProductAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public ProductService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task AddProduct(ProductDto productDto)
        {
            Product data = _mapper.Map<Product>(productDto);
            await _db.Products.AddAsync(data);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            IEnumerable<Product> products = await _db.Products.ToListAsync();
            IEnumerable<ProductDto> productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productDtos;
        }

        public async Task<ProductDto> GetProductById(Guid productId)
        {
            Product product = await _db.Products.FirstAsync(p => p.ProductId == productId);
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
        public async Task DeleteProduct(Guid productId)
        {
            Product data = await _db.Products.FirstAsync(product => product.ProductId == productId);
            _db.Products.Remove(data);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            Product data = _mapper.Map<Product>(productDto);
            _db.Products.Update(data);
            await _db.SaveChangesAsync();
        }
    }
}
