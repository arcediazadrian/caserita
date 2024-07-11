using Caserita_Domain.Exceptions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Caserita_Presentation.Middlewares
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
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error processing invocation");

                var httpReqData = await context.GetHttpRequestDataAsync();

                if (httpReqData != null)
                {
                    var invocationResult = context.GetInvocationResult();
                    invocationResult.Value = await BuildHttpResponse(exception, httpReqData);
                }
            }
        }

        private async Task<HttpResponseData> BuildHttpResponse(Exception exception, HttpRequestData httpReqData)
        {
            HttpResponseData httpResponse;
            switch (exception)
            {
                case InvalidInputException ex:
                    httpResponse = httpReqData.CreateResponse(HttpStatusCode.BadRequest);
                    await httpResponse.WriteAsJsonAsync(new { ExceptionMessage = ex.Message }, httpResponse.StatusCode);
                    break;
                default:
                    // Create an instance of HttpResponseData with 500 status code.
                    httpResponse = httpReqData.CreateResponse(HttpStatusCode.InternalServerError);
                    // You need to explicitly pass the status code in WriteAsJsonAsync method.
                    // https://github.com/Azure/azure-functions-dotnet-worker/issues/776
                    await httpResponse.WriteAsJsonAsync(new { FooStatus = "Invocation failed!" }, httpResponse.StatusCode);
                    break;
            }
            return httpResponse;
        }
    }
}
