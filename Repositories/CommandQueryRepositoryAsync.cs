using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class CommandQueryRepositoryAsync<TContext> : QueryRepositoryAsync<TContext>, ICommandQueryRepositoryAsync where TContext : DbContext
    {
        public CommandQueryRepositoryAsync(TContext context) : base(context, tracking: true)
        {
        }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public void CreateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            DbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Set<TEntity>().Update(entity);
        }

        public void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            DbContext.Set<TEntity>().UpdateRange(entities);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}