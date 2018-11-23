using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories
{
    public class QueryRepository<TContext> : IQueryRepository where TContext : DbContext
    {
        public readonly TContext DbContext;
        private readonly bool _tracking;

        public QueryRepository(TContext context, bool tracking = false)
        {
            DbContext = context;
            _tracking = tracking;
        }

        #region GetAll

        public IEnumerable<TEntity> GetAll<TEntity>(
            string includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class => Get(filter: null, includeProperties: includeProperties, orderBy: orderBy, skip: skip, take: take);

        public IEnumerable<TEntity> GetAll<TEntity>(string includeProperties) where TEntity : class
            => GetAll<TEntity>(includeProperties, null, null, null);

        public IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class
            => GetAll(null, orderBy, null, null);

        public IEnumerable<TEntity> GetAll<TEntity>(int skip, int take) where TEntity : class
            => GetAll<TEntity>(null, null, skip, take);

        public IEnumerable<TEntity> GetAll<TEntity>(string includeProperties, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class
            => GetAll<TEntity>(includeProperties, orderBy, null, null);

        public IEnumerable<TEntity> GetAll<TEntity>(string includeProperties, int skip, int take) where TEntity : class
            => GetAll<TEntity>(includeProperties, null, skip, take);

        public IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int skip, int take) where TEntity : class
            => GetAll(null, orderBy, skip, take);

        #endregion GetAll

        #region GetWithExpression

        public IEnumerable<TEntity> Get<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        string includeProperties = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        int? skip = null,
        int? take = null)
        where TEntity : class =>
        GetQueryable(filter, includeProperties, orderBy, skip, take).ToList();

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class => Get(filter, null, null, null, null);

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties)
            where TEntity : class => Get(filter, includeProperties, null, null, null);

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
            where TEntity : class => Get(filter, null, orderBy, null, null);

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, int skip, int take)
            where TEntity : class => Get(filter, null, null, skip, take);

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
            where TEntity : class => Get(filter, includeProperties, orderBy, null, null);

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties, int skip, int take)
            where TEntity : class => Get(filter, includeProperties, null, skip, take);

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int skip, int take)
            where TEntity : class => Get(filter, null, orderBy, skip, take);

        #endregion GetWithExpression

        #region GetWithSpecification

        public IEnumerable<TEntity> Get<TEntity>(
            ISpecification<TEntity> spec = null,
            string includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null) where TEntity : class
            => GetQueryable(spec, includeProperties, orderBy, skip, take).ToList();

        public IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec)
            where TEntity : class => Get(spec, null, null, null, null);

        public IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec, string includeProperties)
            where TEntity : class => Get(spec, includeProperties, null, null, null);

        public IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
            where TEntity : class => Get(spec, null, orderBy, null, null);

        public IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec, int skip, int take)
            where TEntity : class => Get(spec, null, null, skip, take);

        public IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec, string includeProperties, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
            where TEntity : class => Get(spec, includeProperties, orderBy, null, null);

        public IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec, string includeProperties, int skip, int take)
            where TEntity : class => Get(spec, includeProperties, null, skip, take);

        public IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int skip, int take)
            where TEntity : class => Get(spec, null, orderBy, skip, take);

        #endregion GetWithSpecification

        #region GetOne

        public TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
            => GetQueryable(filter, includeProperties).SingleOrDefault();

        public TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class => GetOne(filter, null);

        public TEntity GetOne<TEntity>(ISpecification<TEntity> spec = null, string includeProperties = null) where TEntity : class
            => GetQueryable(spec, includeProperties).SingleOrDefault();

        public TEntity GetOne<TEntity>(ISpecification<TEntity> spec) where TEntity : class => GetOne(spec, null);

        #endregion GetOne

        #region GetCount

        public int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class => GetQueryable(filter).Count();

        public int GetCount<TEntity>(ISpecification<TEntity> spec = null) where TEntity : class => GetQueryable(spec).Count();

        #endregion GetCount

        #region IsExists

        public bool IsExists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class => GetQueryable(filter).Any();

        public bool IsExists<TEntity>(ISpecification<TEntity> spec = null) where TEntity : class => GetQueryable(spec).Any();

        #endregion IsExists

        protected IQueryable<TEntity> GetQueryable<TEntity>(
            ISpecification<TEntity> spec = null,
            string includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            Expression<Func<TEntity, bool>> filter = spec?.ToExpression();
            return GetQueryable(filter, includeProperties, orderBy, skip, take);
        }

        protected IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;

            IQueryable<TEntity> query;

            if (_tracking)
            {
                query = DbContext.Set<TEntity>();
            }
            else
            {
                query = DbContext.Set<TEntity>().AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }
    }
}