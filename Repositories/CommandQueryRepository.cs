﻿using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using System.Collections.Generic;

namespace Repositories
{
    public class CommandQueryRepository<TContext> : QueryRepository<TContext>, ICommandQueryRepository where TContext : DbContext
    {
        public CommandQueryRepository(TContext context) : base(context, tracking: true)
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
    }
}