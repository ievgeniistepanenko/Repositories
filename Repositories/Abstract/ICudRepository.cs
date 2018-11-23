using System.Collections.Generic;

namespace Repositories.Abstract
{
    public interface ICudRepository
    {
        void Create<TEntity>(TEntity entity) where TEntity : class;

        void CreateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        void DeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    }
}