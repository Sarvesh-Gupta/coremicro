namespace MicroCore.Common.Services
{
    using System;
    using System.Threading.Tasks;
    using MicroCore.Common.Commands;
    using MicroCore.Common.Events;
    using MicroCore.Common.RabbitMq;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using RawRabbit;

    public class ServiceHost : IServiceHost
    {
        private readonly IWebHost _webhost;

        public ServiceHost(IWebHost webHost)
        {
            _webhost = webHost;
        }

        public async Task Run() => await _webhost.RunAsync();

        public static HostBuilder Create<TStartup>(string[] args) where TStartup : class
        {
            Console.Title = typeof(TStartup).Namespace;

            // create configuration to be used in webhost
            var config = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                                .UseConfiguration(config)
                                .UseStartup<TStartup>();

            return new HostBuilder(webHostBuilder.Build());
        }
    }

    public abstract class BuilderBase
    {
        public abstract ServiceHost Build();
    }

    public class HostBuilder : BuilderBase
    {
        private readonly IWebHost _webhost;
        private IBusClient _bus;

        public HostBuilder(IWebHost webHost)
        {
            _webhost = webHost;
        }

        public BusBuilder UserRabbitMq()
        {
            _bus = (IBusClient)_webhost.Services.GetService(typeof(IBusClient));

            return new BusBuilder(_webhost, _bus);
        }
        public override ServiceHost Build()
        {
            return new ServiceHost(_webhost);
        }
    }

    public class BusBuilder : BuilderBase
    {
        private readonly IWebHost _webhost;
        private readonly IBusClient _bus;

        public BusBuilder(IWebHost webhost, IBusClient bus)
        {
            _webhost = webhost;
            _bus = bus;
        }

        public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
        {
            var handler = (ICommandHandler<TCommand>)_webhost.Services.GetService(typeof(ICommandHandler<TCommand>));
            _bus.WithCommandHandlerAsync(handler);

            return this;
        }

        public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
        {
            var handler = (IEventHandler<TEvent>)_webhost.Services.GetService(typeof(IEventHandler<TEvent>));
            _bus.WithEventHandlerAsync(handler);

            return this;
        }
        public override ServiceHost Build()
        {
            return new ServiceHost(_webhost);
        }
    }
}