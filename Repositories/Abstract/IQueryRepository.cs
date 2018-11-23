using Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.Abstract
{
    public interface IQueryRepository
    {
        #region GetAll

        IEnumerable<TEntity> GetAll<TEntity>(
            string includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        IEnumerable<TEntity> GetAll<TEntity>(string includeProperties) where TEntity : class;

        IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class;

        IEnumerable<TEntity> GetAll<TEntity>(int skip, int take) where TEntity : class;

        IEnumerable<TEntity> GetAll<TEntity>(string includeProperties, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class;

        IEnumerable<TEntity> GetAll<TEntity>(string includeProperties, int skip, int take) where TEntity : class;

        IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int skip, int take) where TEntity : class;

        #endregion GetAll

        #region GetWithExpression

        IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, int skip, int take) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties, int skip, int take) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int skip, int take) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null) where TEntity : class;

        #endregion GetWithExpression

        #region GetWithSpecification

        IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec, string includeProperties) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec, int skip, int take) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec, string includeProperties, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec, string includeProperties, int skip, int take) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> spec, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int skip, int take) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(
            ISpecification<TEntity> spec = null,
            string includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null) where TEntity : class;

        #endregion GetWithSpecification

        #region GetOne

        TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class;

        TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class;

        TEntity GetOne<TEntity>(ISpecification<TEntity> spec) where TEntity : class;

        TEntity GetOne<TEntity>(ISpecification<TEntity> spec = null, string includeProperties = null) where TEntity : class;

        #endregion GetOne

        #region GetCount

        int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        int GetCount<TEntity>(ISpecification<TEntity> spec = null)
            where TEntity : class;

        #endregion GetCount

        #region IsExists

        bool IsExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
           where TEntity : class;

        bool IsExists<TEntity>(ISpecification<TEntity> spec = null)
           where TEntity : class;

        #endregion IsExists
    }
}