namespace Nandalala.Paas.Core.Eventing
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        void Handle(TEvent eventToHandle);
    }
}
