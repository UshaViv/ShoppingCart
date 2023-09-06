using ShoppingCartAPI.Models;
using ShoppingCartAPI.Repositories;

namespace ShoppingCartAPI.Services
{
    public interface ICartItemService : IRepository<CartItem>
    {
        Task<List<CartItem>> GetUserCartsAsync(int userId);
        Task<CartItem> GetCartItemASync(int productId);
    }
}
