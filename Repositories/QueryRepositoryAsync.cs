using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories
{
    public class QueryRepositoryAsync<TContext> : QueryRepository<TContext>, IQueryRepositoryAsync where TContext : DbContext
    {
        public QueryRepositoryAsync(TContext context, bool tracking = false)
            : base(context, tracking) { }

        #region GetAllAsync

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            string includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null) where TEntity : class
            =>
            await GetAsync(filter: null, includeProperties: includeProperties, orderBy: orderBy, skip: skip, take: take);

        public Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(string includeProperties) where TEntity : class
            => GetAllAsync<TEntity>(includeProperties, null, null, null);

        public Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class
            => GetAllAsync(null, orderBy, null, null);

        public Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(int skip, int take) where TEntity : class
            => GetAllAsync<TEntity>(null, null, skip, take);

        public Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(string includeProperties, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class
            => GetAllAsync<TEntity>(includeProperties, orderBy, null, null);

        public Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(string includeProperties, int skip, int take) where TEntity : class
            => GetAllAsync<TEntity>(includeProperties, null, skip, take);

        public Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int skip, int take) where TEntity : class
                => GetAllAsync(null, orderBy, skip, take);

        #endregion GetAllAsync

        #region GetAsyncWithExpression

        public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null) where TEntity : class
            => await GetQueryable(filter, includeProperties, orderBy, skip, take).ToListAsync();

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
            => GetAsync(filter, null, null, null, null);

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties) where TEntity : class
            => GetAsync(filter, includeProperties, null, null, null);

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class
            => GetAsync(filter, null, orderBy, null, null);

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, int skip, int take) where TEntity : class
            => GetAsync(filter, null, null, skip, take);

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class
            => GetAsync(filter, includeProperties, orderBy, null, null);

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties, int skip, int take) where TEntity : class
            => GetAsync(filter, includeProperties, null, skip, take);

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int skip, int take) where TEntity : class
            => GetAsync(filter, null, orderBy, skip, take);

        #endregion GetAsyncWithExpression

        #region GetAsyncWithSpecification

        public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
          ISpecification<TEntity> spec = null,
          string includeProperties = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          int? skip = null,
          int? take = null) where TEntity : class
          => await GetQueryable(spec, includeProperties, orderBy, skip, take).ToListAsync();

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec) where TEntity : class
            => GetAsync(spec, null, null, null, null);

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec, string includeProperties) where TEntity : class
            => GetAsync(spec, includeProperties, null, null, null);

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class
            => GetAsync(spec, null, orderBy, null, null);

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec, int skip, int take) where TEntity : class
            => GetAsync(spec, null, null, skip, take);

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec, string includeProperties, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class
            => GetAsync(spec, includeProperties, orderBy, null, null);

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec, string includeProperties, int skip, int take) where TEntity : class
            => GetAsync(spec, includeProperties, null, skip, take);

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(ISpecification<TEntity> spec, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int skip, int take) where TEntity : class
            => GetAsync(spec, null, orderBy, skip, take);

        #endregion GetAsyncWithSpecification

        #region GetOneAsync

        public async Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
            => await GetQueryable(filter, includeProperties).SingleOrDefaultAsync();

        public Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class => GetOneAsync(filter, null);

        public async Task<TEntity> GetOneAsync<TEntity>(ISpecification<TEntity> spec = null, string includeProperties = null) where TEntity : class
            => await GetQueryable(spec, includeProperties).SingleOrDefaultAsync();

        public Task<TEntity> GetOneAsync<TEntity>(ISpecification<TEntity> spec) where TEntity : class => GetOneAsync(spec, null);

        #endregion GetOneAsync

        #region GetCountAsync

        public async Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
            => await GetQueryable(filter).CountAsync();

        public async Task<int> GetCountAsync<TEntity>(ISpecification<TEntity> spec = null) where TEntity : class
            => await GetQueryable(spec).CountAsync();

        #endregion GetCountAsync

        #region IsExistsAsync

        public async Task<bool> IsExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
            => await GetQueryable(filter).AnyAsync();

        public async Task<bool> IsExistsAsync<TEntity>(ISpecification<TEntity> spec = null) where TEntity : class
            => await GetQueryable(spec).AnyAsync();

        #endregion IsExistsAsync
    }
}