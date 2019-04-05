using JsonPlaceHolderDependencyInjection.Function.Models.Clients;
using JsonPlaceHolderDependencyInjection.Function.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonPlaceHolderDependencyInjection
{
    public class Startup : IWebJobsStartup
    {
        public static IConfigurationRoot _configuration;

        public void Configure(IWebJobsBuilder builder)
        {
            // Initialize serilog logger
            Log.Logger = new LoggerConfiguration()
                 .WriteTo.Console(Serilog.Events.LogEventLevel.Debug)
                 .MinimumLevel.Debug()
                 .Enrich.FromLogContext()
                 .CreateLogger();

            builder.Services
                .AddSingleton<ILogger>(Log.Logger)
                .AddTransient<IJsonPlaceholderClient, JsonPlaceholderClient>(client =>
                    new JsonPlaceholderClient(Environment.GetEnvironmentVariable("BaseAddress"))
                )
                .AddTransient<IJsonPlaceholderService, JsonPlaceholderService>()
                .BuildServiceProvider(true);
        }
    }
}
