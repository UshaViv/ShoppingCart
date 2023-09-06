using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.PayloadModels;
using ShoppingCartAPI.Services;

namespace ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(UserPayload userPayload)
        {
            if (userPayload == null)
            {
                return BadRequest("User Payload should not be null");
            }

            User user = new() { Name = userPayload.Name, PhoneNumber = userPayload.PhoneNumber };
            await _userService.AddAsync(user, default);
            return Ok();
        }
    }
}
