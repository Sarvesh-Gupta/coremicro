namespace MicroCore.Api.Handlers
{
    using System;
    using System.Threading.Tasks;
    using MicroCore.Common.Events;
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated>
    {
        public async Task HandleAsync(ActivityCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Activity Created: {@event.Name}");
        }
    }
}