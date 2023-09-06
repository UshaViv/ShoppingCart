using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.CartDbContext;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Repositories;

namespace ShoppingCartAPI.Services
{
    public class CartItemService : Repository<CartItem>, ICartItemService
    {
        public CartItemService(ShoppingCartDbContext dbContext)
            : base(dbContext) { }

        public async Task<List<CartItem>> GetUserCartsAsync(int userId)
        {
            Expression<Func<CartItem, bool>> selector = o => o.UserId == userId;
            return await GetAllAsync(selector);
        }

        public async Task<CartItem> GetCartItemASync(int productId)
        {
             Expression<Func<CartItem, bool>> selector = o => o.ProductId == productId;
            return await GetAsync(selector);
        }
    }
}
