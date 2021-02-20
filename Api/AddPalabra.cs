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

namespace BlazorApp.Api
{
    public static class AddPalabra
    {
        [FunctionName("AddPalabra")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "palabras",
                collectionName: "ContainerMain",
                SqlQuery = "SELECT * FROM ContainerMain",
                ConnectionStringSetting = "PalabrasConnectionString")] IAsyncCollector<object> palabras,
            ILogger log)
        {


            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                var input = JsonConvert.DeserializeObject<Palabra>(requestBody);

                await palabras.AddAsync(input);
                return new OkObjectResult(input);

            } catch (Exception ex)
            {
                log.LogError($"Couldn't insert item. Exception thrown: {ex.Message}");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
            
            

        }
    }

