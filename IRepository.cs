using System.Collections.Generic;
using NHibernate;

namespace NullReference.Data
{
    public interface IRepository
    {
        void Delete<T>(T entity);
        void Save<T>(T entity);
        IQueryResult<T> Query<T>(IQuery<T> query);
        bool Exists<T>(IBooleanQuery<T> query);
    }

    public interface IBooleanQuery<out T>
    {
        bool Execute(ISession session);
    }

    public interface IQuery<out T> 
    {
        IQueryResult<T> Execute(ISession session);
    }

    public interface IQueryResult<out T> 
    {
        T Unique();
        T UniqueOrDefault();
        IEnumerable<T> List();
    }
}