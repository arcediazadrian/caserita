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
                    await httpResponse.WriteAsJsonAsync(new { Message = ex.Message }, httpResponse.StatusCode);
                    break;
                default:
                    httpResponse = httpReqData.CreateResponse(HttpStatusCode.InternalServerError);
                    await httpResponse.WriteAsJsonAsync(new { Message = "Something went wrong!" }, httpResponse.StatusCode);
                    break;
            }
            return httpResponse;
        }
    }
}
