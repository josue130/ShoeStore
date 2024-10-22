using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Services.ShoppingCartAPI.Data;
using Store.Services.ShoppingCartAPI.Models;
using Store.Services.ShoppingCartAPI.Models.Dto;
using Store.Services.ShoppingCartAPI.Service.IService;

namespace Store.Services.ShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartAPIController : ControllerBase
    {
  
        private readonly ICartService _cartService;
        private ResponseDto _response;
        public CartAPIController(ICartService cartService)
        {
            _cartService = cartService;
            _response = new();
        }
        [HttpPost("CartUpsert")]
        public async Task<IActionResult> CartUpsert(CartDto cartDto)
        {
            try
            {
                CartDto result  = await _cartService.CartUpsert(cartDto);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return Ok(_response);
        }
        [HttpPost("RemoveCart")]
        public async Task<ResponseDto> RemoveCart([FromBody] Guid cartDetailId)
        {
            try
            {
                await _cartService.RemoveCart(cartDetailId);

                _response.Result = true;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return _response;
        }
        [HttpGet("GetCart/{userId}")]
        public async Task<ResponseDto> GetCart(string userId)
        {
            try
            {
                CartDto cart = await _cartService.GetCart(userId);

                _response.Result = cart;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return _response;
        }
    }
}
