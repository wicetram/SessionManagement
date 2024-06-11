using System.Linq.Expressions;

namespace Management.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, new()
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>>? filter = null);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
