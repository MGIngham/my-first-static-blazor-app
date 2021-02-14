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
using System.Collections.Generic;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Linq;
using System.Net;

namespace BlazorApp.Api
{
    public static class GetPalabras
    {
        [FunctionName("GetPalabras")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "palabras",
                collectionName: "ContainerMain",
                SqlQuery = "SELECT * FROM ContainerMain",
                ConnectionStringSetting = "PalabrasConnectionString")]
                IEnumerable<Palabra> item,
            ILogger log)
        {


            return new OkObjectResult(item);
        }
    }
}
