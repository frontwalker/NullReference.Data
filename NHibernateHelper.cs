using NHibernate;

namespace NullReference.Data
{
    public static class NHibernateHelper
    {
        private static ISessionProvider _sessionProvider;
        private static IStateHolder _stateHolder;
        private const string sessionKey = "nhibernate.current.session";

        public static void Initialize(ISessionProvider sessionProvider, IStateHolder stateHolder)
        {
            _sessionProvider = sessionProvider;
            _stateHolder = stateHolder;
        }

        public static ISession GetCurrentSession()
        {
            if (_stateHolder[sessionKey] == null)
                _stateHolder[sessionKey] = _sessionProvider.CreateNewSession();
            return (ISession)_stateHolder[sessionKey];
        }

        public static void BeginTransaction()
        {
            GetCurrentSession().BeginTransaction();
        }

        public static void CommitTransaction()
        {
            GetCurrentSession().Transaction.Commit();
            _stateHolder[sessionKey] = null;
        }

        public static void RollbackTransaction()
        {
            GetCurrentSession().Transaction.Rollback();
            _stateHolder[sessionKey] = null;
        }
    }
}