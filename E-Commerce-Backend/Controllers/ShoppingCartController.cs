using E_Commerce_Backend.DTO;
using E_Commerce_Backend.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CartItemDTO cartItemDto)
        {
            await _shoppingCartService.AddToCart(cartItemDto.UserId, cartItemDto.ProductId, cartItemDto.Quantity);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCartItem([FromBody] CartItemUpdateDTO cartItemUpdateDto)
        {
            await _shoppingCartService.UpdateCartItem(cartItemUpdateDto.CartItemId, cartItemUpdateDto.Quantity);
            return Ok();
        }

        [HttpDelete("remove/{cartItemId}")]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            await _shoppingCartService.RemoveFromCart(cartItemId);
            return Ok();
        }

       // [HttpGet]
        //public async Task<IActionResult> GetCartItems(int userId)
        //{
        //    var cartItems = await _shoppingCartService.GetCartItems(userId);
        //    return Ok(cartItems);
        //}

        [HttpGet("total")]
        public async Task<IActionResult> GetCartTotalAmount(int userId)
        {
            var totalAmount = await _shoppingCartService.GetCartTotalAmount(userId);
            return Ok(totalAmount);
        }
    }


}
