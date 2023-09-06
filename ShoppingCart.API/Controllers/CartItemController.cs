using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.PayloadModels;
using ShoppingCartAPI.Services;

namespace ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemsController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CartItemPayload cartItemPayload)
        {
            if (cartItemPayload == null)
            {
                return BadRequest("User Payload should not be null");
            }

            CartItem cartItem =
                new()
                {
                    ProductId = cartItemPayload.ProductId,
                    UserId = cartItemPayload.UserId,
                    Quantity = cartItemPayload.Quantity.HasValue ? cartItemPayload.Quantity : 1
                };
            await _cartItemService.AddAsync(cartItem, default);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(CartItemPayload cartItemPayload)
        {
            var cartItem = await _cartItemService.GetCartItemASync(cartItemPayload.ProductId);

            int updatedQuantity = 0;
            if (cartItem.Quantity.HasValue && cartItemPayload.Quantity.HasValue)
                updatedQuantity = (int)cartItem.Quantity - (int)cartItemPayload.Quantity;

            if (updatedQuantity == 0)
            {
                _cartItemService.Remove(cartItem);
            }
            else
            {
                cartItem.Quantity = updatedQuantity;
                _cartItemService.Update(cartItem);          
            }
             return Ok();
        }

        [HttpGet("user/{userId}")]
        public IActionResult Get(int userId)
        {
            var usersCart = _cartItemService.GetUserCartsAsync(userId);
            return Ok(usersCart);
        }
    }
}
