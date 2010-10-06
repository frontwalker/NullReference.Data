using NHibernate.Event;
using NHibernate.Event.Default;

namespace NullReference.Data.Events
{
    public class SaveEventListener : DefaultSaveOrUpdateEventListener
    {
      
        protected override object EntityIsTransient(SaveOrUpdateEvent @event)
        {
            var entity = @event.Entity as ISaveAwareEntity;
            if (entity != null)
                entity.OnSave();

            return base.EntityIsTransient(@event);
        }

        protected override object EntityIsPersistent(SaveOrUpdateEvent @event)
        {
            var entity = @event.Entity as IUpdateAwareEntity;
            if (entity != null)
                entity.OnUpdate();

            return base.EntityIsPersistent(@event); ;
        }

    }
}