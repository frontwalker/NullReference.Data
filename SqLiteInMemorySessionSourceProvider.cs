using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
using NullReference.Data.Events;

namespace NullReference.Data
{
    public class SqLiteInMemorySessionSourceProvider : ISessionSourceProvider
    {
        readonly IPersistenceMappings _mappings;

        public SqLiteInMemorySessionSourceProvider(IPersistenceMappings mappings)
        {
            _mappings = mappings;
        }

        public ISessionSource GetSessionSource()
        {
            var config = _mappings.Generate()
                .Database(SQLiteConfiguration.Standard.InMemory()
                              .ProxyFactoryFactory(typeof(NHibernate.ByteCode.LinFu.ProxyFactoryFactory)))
                .ExposeConfiguration(EventListenerRegistrations.Apply);

            var sessionSource = new SessionSource(config);

            if (ShouldGenerateDb)
                sessionSource.BuildSchema();

            return sessionSource;
        }

        public bool ShouldGenerateDb { get; set; }
    }
}