namespace MicroCore.Common.Events
{
    public interface IEventHandler<in T> where T : IEvent
    {
        void HandleAsync(T @event);
    }
}