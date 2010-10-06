using System;
using System.Collections.Generic;
using System.Data;
using NHibernate;

namespace NullReference.Data
{
    public class QueryResult<T> : IQueryResult<T> where T : class
    {
        private readonly IQuery _query;

        public QueryResult(IQuery query)
        {
            this._query = query;
        }

        public T Unique()
        {
            var result = (T)_query.UniqueResult();

            if(result == null)
                throw (new NoNullAllowedException("Unique result returned not allowed null value"));

            return result;
        }

        public T UniqueOrDefault()
        {
            return _query.UniqueResult<T>();
        }

        public IEnumerable<T> List()
        {
            return _query.List<T>();
        }

    }
}