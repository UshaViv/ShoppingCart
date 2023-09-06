using System.Linq.Expressions;

namespace ShoppingCartAPI.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        void Remove(T entity);
        void Update(T entity);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
    }
}