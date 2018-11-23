using Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Abstract
{
    public interface IQueryRepositoryAsync : IQueryRepository
    {
        #region GetAll

        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            string includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(string includeProperties) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(int skip, int take) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(string includeProperties, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(string includeProperties, int skip, int take) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int skip, int take) where TEntity : class;

        #endregion GetAll

        #region GetWithExpression

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, int skip, int take) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties, int skip, int take) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int skip, int take) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null) where TEntity : class;

        #endregion GetWithExpression

        #region GetWithSpecification

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec, string includeProperties) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec, int skip, int take) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec, string includeProperties, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec, string includeProperties, int skip, int take) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int skip, int take) where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            ISpecification<TEntity> spec = null,
            string includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null) where TEntity : class;

        #endregion GetWithSpecification

        #region GetOne

        Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class;

        Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class;

        Task<TEntity> GetOneAsync<TEntity>(ISpecification<TEntity> spec) where TEntity : class;

        Task<TEntity> GetOneAsync<TEntity>(ISpecification<TEntity> spec = null, string includeProperties = null) where TEntity : class;

        #endregion GetOne

        #region GetCount

        Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        Task<int> GetCountAsync<TEntity>(ISpecification<TEntity> spec = null)
            where TEntity : class;

        #endregion GetCount

        #region IsExists

        Task<bool> IsExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
           where TEntity : class;

        Task<bool> IsExistsAsync<TEntity>(ISpecification<TEntity> spec = null)
           where TEntity : class;

        #endregion IsExists
    }
}