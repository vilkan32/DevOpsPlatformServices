using DevOpsPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DevOpsPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private HttpClient _httpClient;
        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        [Route("Webhook")]
        public async Task<IActionResult> TriggerWebhook()
        {
            try
            {
                var body = string.Empty;
                using StreamReader stream = new StreamReader(this.HttpContext.Request.Body);

                body = await stream.ReadToEndAsync();

                var parsedResponse = JsonConvert.DeserializeObject<Payload>(body);

                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", "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");
                _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("vilkan32");

                using var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.github.com/repos/vilkan32/DevOpsPlatformServices/issues/{parsedResponse.Issue.Number}/comments");

                var commentMessage = "Thanks for submitting this issue. Our Team will get back to you as soon as possible!";

                request.Content = JsonContent.Create(new { body = commentMessage });

                var response = await _httpClient.SendAsync(request);

                return Ok(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
