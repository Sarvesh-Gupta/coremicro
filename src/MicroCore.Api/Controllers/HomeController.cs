namespace MicroCore.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from microcore!");
    }
}