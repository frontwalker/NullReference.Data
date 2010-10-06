using FluentNHibernate.Cfg;

namespace NullReference.Data
{
    public interface IPersistenceMappings
    {
        FluentConfiguration Generate();
       
    }
}