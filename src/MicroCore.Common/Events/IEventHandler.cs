namespace MicroCore.Common.Events
{
    using System.Threading.Tasks;
    
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}