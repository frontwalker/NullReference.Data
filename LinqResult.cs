using System;
using System.Collections.Generic;
using System.Linq;

namespace NullReference.Data
{
    public class LinqResult<T> : IQueryResult<T>
    {
        private readonly IQueryable<T> _query;

        public LinqResult(IQueryable<T> query)
        {
            _query = query;
        }

        public T Unique()
        {
            return _query.First();
        }

        public T UniqueOrDefault()
        {
            return _query.SingleOrDefault();
        }

        public IEnumerable<T> List()
        {
            return _query;
        }
    }
}