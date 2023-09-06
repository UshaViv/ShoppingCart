using ShoppingCartAPI.Models;
using ShoppingCartAPI.Repositories;

namespace ShoppingCartAPI.Services
{
    public interface IProductService : IRepository<Product> { }
}