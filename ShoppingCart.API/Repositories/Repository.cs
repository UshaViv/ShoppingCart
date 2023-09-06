using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.CartDbContext;

namespace ShoppingCartAPI.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly ShoppingCartDbContext _dbContext;
        private readonly DbSet<T> _entitiySet;

        public Repository(ShoppingCartDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitiySet = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(entity, cancellationToken);
            SaveChanges();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            
            return await _entitiySet.FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return await _entitiySet.Where(expression).ToListAsync();
        }

        public void Remove(T entity)
        {
            _dbContext.Remove(entity);
            SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
