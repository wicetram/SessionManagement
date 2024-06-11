using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Management.Core.DataAccess.EntityFramework
{
    public class EntityRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter)
        {
            using var context = new TContext();
            return filter == null ? null : await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            using var context = new TContext();
            return filter == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            using var context = new TContext();
            await context.Set<TEntity>().AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Update(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync();
        }
    }
}
