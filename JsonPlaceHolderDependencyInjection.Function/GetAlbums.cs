﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Hosting;
using JsonPlaceHolderDependencyInjection;
using JsonPlaceHolderDependencyInjection.Function.Services;
using Microsoft.Extensions.Logging;

[assembly: WebJobsStartup(typeof(Startup))]

namespace JsonPlaceHolderDependencyInjection.Function
{
    public class GetAlbums
    {
        private readonly IJsonPlaceholderService _jsonPlaceholderService;
        private readonly ILogger _logger;

        public GetAlbums(IJsonPlaceholderService jsonPlaceholderService, ILoggerFactory loggerFactory)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
            _logger = loggerFactory.CreateLogger("GetAlbums");
        }

        [FunctionName("GetAlbums")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetAlbums/{id?}")] HttpRequest req, int? id)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            //log.LogInformation("C# HTTP trigger function processed a request.");

            if (id == null)
            {
                return (ActionResult)new OkObjectResult(await _jsonPlaceholderService.GetAlbums());
            }
            else
            {
                return (ActionResult)new OkObjectResult(await _jsonPlaceholderService.GetAlbumById((int)id));
            }
        }
    }
}
