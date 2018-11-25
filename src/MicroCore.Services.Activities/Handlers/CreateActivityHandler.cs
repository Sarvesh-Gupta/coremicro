namespace MicroCore.Services.Activities.Handlers
{
    using System;
    using System.Threading.Tasks;
    using MicroCore.Common.Commands;
    using MicroCore.Common.Events;
    using RawRabbit;

    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _bus;

        public CreateActivityHandler(IBusClient bus)
        {
            _bus = bus;
        }

        public async Task HandleAsync(CreateActivity command)
        {
            Console.WriteLine($"Creating Activity: {command.Name}");
            await _bus.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category,
            command.Name, command.Description, command.CreatedAt));
        }
    }
}