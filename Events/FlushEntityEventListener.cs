using NHibernate.Event;
using NHibernate.Event.Default;

namespace NullReference.Data.Events
{
    public class FlushEntityEventListener:DefaultFlushEntityEventListener
    {
        public override void OnFlushEntity(FlushEntityEvent @event)
        {
            var entity = @event.Entity as IUpdateAwareEntity;
            if (entity != null)
                entity.OnUpdate(); 
            base.OnFlushEntity(@event);
        }
    }
}