using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Services.ProductAPI.Models;
using Store.Services.ProductAPI.Models.Dto;
using Store.Services.ProductAPI.Service.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ResponseDto _response;
        public ProductAPIController(IProductService productService)
        {
            _productService = productService;
            _response = new();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<ProductDto> data = await _productService.GetAllProducts();
                _response.Result = data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
            return Ok(_response);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                ProductDto data = await _productService.GetProductById(id);
                _response.Result = data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
            return Ok(_response);
        }
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Post([FromBody] ProductDto model)
        {
            try
            {
                await _productService.AddProduct(model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
            return Ok(_response);
        }
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Put([FromBody] ProductDto model)
        {
            try
            {
                await _productService.UpdateProduct(model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
            return Ok(_response);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _productService.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}
