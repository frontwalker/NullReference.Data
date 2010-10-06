using NHibernate;

namespace NullReference.Data
{
    public interface ISessionProvider
    {
        ISession CreateNewSession();
    }
}