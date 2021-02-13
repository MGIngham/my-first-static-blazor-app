using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BlazorApp.Shared;

namespace BlazorApp.Api
{
    public static class GetPalabras
    {
        [FunctionName("GetPalabras")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {


            Palabra palabra = new Palabra
            {
                Id = 1,
                SpanishWord = "Cama",
                EnglishWord = "Bed"
            };

            return new OkObjectResult(palabra);
        }
    }
}
