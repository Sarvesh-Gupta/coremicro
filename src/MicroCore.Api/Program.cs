namespace MicroCore.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using MicroCore.Common.Events;
    using MicroCore.Common.Services;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await ServiceHost.Create<Startup>(args)
            .UserRabbitMq()
            .SubscribeToEvent<ActivityCreated>()
            .Build()
            .RunAsync();
        }

    }
}
