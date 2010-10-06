using System;
using System.Linq;
using NHibernate;

namespace NullReference.Data
{
    public class NHibernateRepository : IRepository
    {
        private readonly ISession _currentSession;

        public NHibernateRepository(ISession session)
        {
            _currentSession = session;
        }

        public void Delete<T>(T entity)
        {
            _currentSession.Delete(entity);
        }

        public void Save<T>(T entity)
        {
            _currentSession.Save(entity);
        }

        public IQueryResult<T> Query<T>(IQuery<T> query)
        {
            return query.Execute(_currentSession);
        }

        public bool Exists<T>(IBooleanQuery<T> query)
        {
            return query.Execute(_currentSession);
        }
    }
}