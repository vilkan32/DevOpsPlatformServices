using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("Webhook")]
        public IActionResult TriggerWebhook()
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(this.Response.Body);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");
            return Ok();
        }
    }
}
