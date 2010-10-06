using NHibernate.Cfg;

namespace NullReference.Data.Events
{
    public class EventListenerRegistrations
    {
        public static void Apply(Configuration configuration)
        {
            configuration.EventListeners.SaveEventListeners = new[] { new SaveEventListener() };
            configuration.EventListeners.UpdateEventListeners = new[] { new SaveEventListener() };
            configuration.EventListeners.SaveOrUpdateEventListeners = new[] { new SaveEventListener() };
            configuration.EventListeners.FlushEntityEventListeners = new[] { new FlushEntityEventListener() };
        }
    }
}