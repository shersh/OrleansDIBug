using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrleanAzureGrains;
using OrleanAzureInterfaces;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

namespace OrleanAzure
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var siloBuilder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "Orleans2GettingStarted";
                })
                .Configure<EndpointOptions>(options =>
                    options.AdvertisedIPAddress = IPAddress.Loopback)
                .ConfigureLogging(logging => logging.AddConsole())
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(MyGrain).Assembly).WithReferences());

            var host = siloBuilder.Build();
            await host.StartAsync();
            Console.ReadLine();
        }
    }
}
