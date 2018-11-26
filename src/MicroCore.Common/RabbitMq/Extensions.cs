namespace MicroCore.Common.RabbitMq
{
    using System.Reflection;
    using System.Threading.Tasks;
    using MicroCore.Common.Commands;
    using MicroCore.Common.Events;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using RawRabbit;
    using RawRabbit.Instantiation;
    using RawRabbit.Pipe.Middleware;

    public static class Extensions
    {
        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler)
            where TEvent : IEvent
         => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
         ctx => ctx.UseConsumeConfiguration(cfg =>
         cfg.FromQueue(GetQueueName<TEvent>())));

        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler)
           where TCommand : ICommand
        => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
        ctx => ctx.UseConsumeConfiguration(cfg => 
        cfg.FromQueue(GetQueueName<TCommand>())));

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration config)
        {
            var options = new RabbitMqOptions();
            var section = config.GetSection("rabbitmq");
            section.Bind(options);

            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });

            services.AddSingleton<IBusClient>(_ => client);
        }

        private static string GetQueueName<T>()
           => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
    }
}