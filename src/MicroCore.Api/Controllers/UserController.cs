namespace MicroCore.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using MicroCore.Common.Commands;
    using Microsoft.AspNetCore.Mvc;
    using RawRabbit;

    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IBusClient _bus;

        public UserController(IBusClient bus)
        {
            _bus = bus;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _bus.PublishAsync(command);

            return Accepted();
        }
    }
}