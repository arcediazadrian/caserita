using System.Net;
using System.Text.Json;
using Domain.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Presentation
{
    public class UserFunction
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public UserFunction(ILoggerFactory loggerFactory, IUserService userService)
        {
            _logger = loggerFactory.CreateLogger<UserFunction>();
            _userService = userService;
        }

        [Function("CreateNewUserFunction")]
        public HttpResponseData CreateNewUser([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var user = JsonSerializer.Serialize(_userService.CreateNewUser());
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            response.WriteString(user);

            return response;
        }
    }
}
