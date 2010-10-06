using FluentNHibernate;

namespace NullReference.Data
{
    public interface ISessionSourceProvider
    {
        ISessionSource GetSessionSource();
    }
}