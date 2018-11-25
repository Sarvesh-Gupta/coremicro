namespace MicroCore.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using MicroCore.Common.Commands;
    using Microsoft.AspNetCore.Mvc;
    using RawRabbit;

    [Route("[controller]")]
    public class ActivitiesController : Controller
    {
        private readonly IBusClient _bus;

        public ActivitiesController(IBusClient bus)
        {
            _bus = bus;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateActivity command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;

            await _bus.PublishAsync(command);

            return Accepted($"activities/{command.Id}");
        }
    }
}