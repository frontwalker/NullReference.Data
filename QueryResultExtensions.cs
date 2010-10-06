using System.Collections.Generic;
using System.Linq;

namespace NullReference.Data
{
    public static class QueryResultExtensions
    {
        public static IQueryResult<T> ToLinqResult<T>(this IEnumerable<T> items) where T : class
        {
            return new LinqResult<T>(items.AsQueryable());
        }

        public static IQueryResult<T> AsLinqResult<T>(this T obj) where T : class
        {
            return new List<T> { obj }.ToLinqResult();
        }
    }
}