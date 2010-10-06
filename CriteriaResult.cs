using System;
using System.Collections.Generic;
using System.Data;
using NHibernate;

namespace NullReference.Data
{
    public class CriteriaResult<T> : IQueryResult<T> where T : class
    {
        private readonly ICriteria _criteria;

        public CriteriaResult(ICriteria criteria)
        {
            _criteria = criteria;
        }

        public T Unique()
        {
            var result = _criteria.UniqueResult<T>();

            if(result == null)
                throw (new NoNullAllowedException("Unique result returned not allowed null value"));

            return result;
        }

        public T UniqueOrDefault()
        {
            return _criteria.UniqueResult<T>();
        }

        public IEnumerable<T> List()
        {
            return _criteria.List<T>();
        }

    }
}