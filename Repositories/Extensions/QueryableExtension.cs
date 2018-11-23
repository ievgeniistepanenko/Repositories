using Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> source, ISpecification<T> spec)
        {
            return source.Where(spec.ToExpression());
        }
    }
}
