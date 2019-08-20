using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OrleanAzureInterfaces;
using Orleans;
using Orleans.Configuration;

[assembly: FunctionsStartup(typeof(OrleanAzureClient.Startup))]
namespace OrleanAzureClient
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var clientBuilder = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "Orleans2GettingStarted";
                });

            var client = clientBuilder.Build();
            client.Connect().Wait();

            builder.Services.AddSingleton(client);

            // UNCOMMENT THIS LINE FOR TESTING PASSING
            // var sensor = client.GetGrain<IUserGrain>(new Random().Next());
        }
    }
}
