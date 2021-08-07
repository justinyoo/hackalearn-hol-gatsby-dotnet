using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using api.Models;

namespace api
{
    public static class WordpressHttpTrigger
    {
        [FunctionName("WordpressHttpTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "posts")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var blogUri = Environment.GetEnvironmentVariable("Wordpress__URL");
            var requestUri = $"https://public-api.wordpress.com/rest/v1.1/sites/{blogUri}/posts/";

            var posts = default(PostCollection);
            using (var http = new HttpClient())
            {
                var response = await http.GetStringAsync(requestUri);
                posts = JsonConvert.DeserializeObject<PostCollection>(response);
            }

            return new OkObjectResult(posts);
        }
    }
}
