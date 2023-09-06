using ShoppingCartAPI.CartDbContext;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Repositories;

namespace ShoppingCartAPI.Services
{
    public class UserService : Repository<User>, IUserService
    {
        public UserService(ShoppingCartDbContext dbContext)
            : base(dbContext) { }
    }
}
