using System;

// AWS
#if PROVIDER_AWS
  using Amazon.Lambda.Core;
  [assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
#endif
// Azure
#if PROVIDER_AZURE 
  using System.IO;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Azure.WebJobs;
  using Microsoft.Azure.WebJobs.Extensions.Http;
  using Microsoft.AspNetCore.Http;
  using Microsoft.Azure.WebJobs.Host;
  using Microsoft.Extensions.Logging;
  using Newtonsoft.Json;
#endif 

namespace AgnosticHello
  {
    // Define expected parameters
    public class Request
    {
        public string Name { get; set; }
    }

    // Function logic
    public class AgnosticRequest
    {
        public string Process(Request request)
        {
          return "Hello from any damn platform " + request.Name;
        }
    }

    
    #if PROVIDER_AWS
      public class Handler
      {
        public string Hello(Request request)
        {
            AgnosticRequest ar = new AgnosticRequest();
            return ar.Process(request);
        }
      }
    #endif

    #if PROVIDER_AZURE
      public static class Handler
      {
          [FunctionName("Hello")]
          public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, ILogger log)
          {
              //log.LogInformation("C# HTTP trigger function processed a request.");
      
              string name = req.Query["name"];

              string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
              dynamic data = JsonConvert.DeserializeObject(requestBody);
              name = name ?? data?.name;

              // TODO: copy all data attributes to Request object
              Request request = new Request();
              request.Name = name;
              
              /*return name != null
                  ? (ActionResult)new OkObjectResult($"Hello, {name}")
                  : new BadRequestObjectResult("Please pass a name on the query string or in the request body");*/

              AgnosticRequest ar = new AgnosticRequest();
              return new OkObjectResult(ar.Process(request));
          }
      }
    #endif 
  }
