using ShoppingCartAPI.CartDbContext;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Repositories;

namespace ShoppingCartAPI.Services
{
    public class ProductService : Repository<Product>, IProductService
    {
        public ProductService(ShoppingCartDbContext dbContext)
            : base(dbContext) { }
    }
}
