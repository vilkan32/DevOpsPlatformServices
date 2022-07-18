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
        public IActionResult TriggerWebhook(string jsonPayload)
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(jsonPayload);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");
            return Ok(jsonPayload);
        }
    }
}
