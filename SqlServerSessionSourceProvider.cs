using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
using NullReference.Data.Events;

namespace NullReference.Data
{
    public class SqlServerSessionSourceProvider:ISessionSourceProvider
    {
        readonly IPersistenceMappings _mappings;
        readonly string _connectionString;
       
        public bool ShouldGenerateDb { get; set; }

        public SqlServerSessionSourceProvider(string connectionString, IPersistenceMappings mappings)
        {
            _connectionString = connectionString;
            _mappings = mappings;
        }

        public ISessionSource GetSessionSource()
        {
            var config = _mappings.Generate()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(_connectionString)
                              .ProxyFactoryFactory(typeof (NHibernate.ByteCode.LinFu.ProxyFactoryFactory)))
                              .ExposeConfiguration(EventListenerRegistrations.Apply);
             
        
            var sessionSource = new SessionSource(config);


            if (ShouldGenerateDb)
                sessionSource.BuildSchema();

            return sessionSource;
        }
    }
}