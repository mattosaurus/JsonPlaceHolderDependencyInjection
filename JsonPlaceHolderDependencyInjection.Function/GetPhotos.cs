using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Hosting;
using JsonPlaceHolderDependencyInjection;
using JsonPlaceHolderDependencyInjection.Function.Services;
using Microsoft.Extensions.Logging;
//using Serilog;

[assembly: WebJobsStartup(typeof(Startup))]

namespace JsonPlaceHolderDependencyInjection.Function
{
    public class GetPhotos
    {
        private readonly IJsonPlaceholderService _jsonPlaceholderService;
        private readonly Serilog.ILogger _logger;

        public GetPhotos(IJsonPlaceholderService jsonPlaceholderService, Serilog.ILogger logger)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
            _logger = logger;
        }

        [FunctionName("GetPhotos")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetPhotos/{id?}")] HttpRequest req, int? id/*, Microsoft.Extensions.Logging.ILogger log*/)
        {
            _logger.Information("C# HTTP trigger function processed a request.");
            //log.LogInformation("C# HTTP trigger function processed a request.");

            if (id == null)
            {
                return (ActionResult)new OkObjectResult(await _jsonPlaceholderService.GetPhotos());
            }
            else
            {
                return (ActionResult)new OkObjectResult(await _jsonPlaceholderService.GetPhotoById((int)id));
            }
        }
    }
}
