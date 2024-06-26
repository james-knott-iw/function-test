using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Http;


namespace IntegrationWorks.Function
{

    public class Message
    {
        public required int Id { get; set; }
    }
    public class order_read
    {
        private readonly ILogger<order_read> _logger;

        public order_read(ILogger<order_read> logger)
        {
            _logger = logger;
        }
        [Function("order_read")]
        public static Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "order_read/{id:int}")] HttpRequestData req, int id)
        {

            string? connectionString = System.Environment.GetEnvironmentVariable("ORDER_READ_QUEUE_KEY");
            if (connectionString != null)
            {

                return Task.FromResult<IActionResult>(new OkObjectResult("Welcome to Azure Functions! \\n " + connectionString));
            }
            return Task.FromResult<IActionResult>(new OkObjectResult("Connection String null"));
        }
    }
}
