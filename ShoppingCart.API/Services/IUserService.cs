using ShoppingCartAPI.Models;
using ShoppingCartAPI.Repositories;

namespace ShoppingCartAPI.Services
{
    public interface IUserService : IRepository<User> { }
}