using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.PayloadModels;
using ShoppingCartAPI.Services;

namespace ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductPayload productPayload)
        {
            if (productPayload == null)
            {
                return BadRequest("Product Payload should not be null");
            }

            Product product =
                new()
                {
                    Name = productPayload.Name,
                    Price = productPayload.Price,
                    InStock = productPayload.InStock
                };
            await _productService.AddAsync(product, default);
            return Ok();
        }
    }
}
