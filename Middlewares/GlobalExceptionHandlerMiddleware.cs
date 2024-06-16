using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IFunctionsWorkerMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
                _logger.LogError(ex, "Error processing invocation");

                var httpReqData = await context.GetHttpRequestDataAsync();

                if (httpReqData != null)
                {
                    // Create an instance of HttpResponseData with 500 status code.
                    var newHttpResponse = httpReqData.CreateResponse(HttpStatusCode.InternalServerError);
                    // You need to explicitly pass the status code in WriteAsJsonAsync method.
                    // https://github.com/Azure/azure-functions-dotnet-worker/issues/776
                    await newHttpResponse.WriteAsJsonAsync(new { FooStatus = "Invocation failed!" }, newHttpResponse.StatusCode);
                    var invocationResult = context.GetInvocationResult();
                    invocationResult.Value = newHttpResponse;
                }
            }
        }
    }
}
