using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OrleanAzureInterfaces;
using Orleans;

namespace OrleanAzureClient
{
    public class Function1
    {
        private readonly IClusterClient _client;

        public Function1(IClusterClient client)
        {
            _client = client;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            int res;
            var sensor = _client.GetGrain<IPlayerGrain>(new Random().Next());
            res = await sensor.GetSomething();

            return new OkObjectResult(new { number = res });
        }
    }
}
