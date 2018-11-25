namespace MicroCore.Common.RabbitMq
{
    using System.Reflection;
    using System.Threading.Tasks;
    using MicroCore.Common.Commands;
    using MicroCore.Common.Events;
    using RawRabbit;
    public static class Extensions
    {
        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler)
            where TEvent : IEvent
         => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
         ctx => ctx.UseSubscribeConfiguration(cfg =>
         cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));

        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler)
           where TCommand : ICommand
        => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
        ctx => ctx.UseSubscribeConfiguration(cfg => 
        cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));

        private static string GetQueueName<T>()
           => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
    }
}