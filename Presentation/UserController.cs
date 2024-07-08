using System.Net;
using System.Text.Json;
using Caserita_Domain.Entities;
using Caserita_Domain.Interfaces;
using Domain.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Presentation
{
    public class UserController
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly IUserRepo _userRepo;

        public UserController(ILoggerFactory loggerFactory, IUserService userService, IUserRepo userRepo)
        {
            _logger = loggerFactory.CreateLogger<UserController>();
            _userService = userService;
            _userRepo = userRepo;
        }

        [Function("CreateNewUserFunction")]
        public async Task<HttpResponseData> CreateNewUser([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            var createdUser = _userService.CreateNewUser();
            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(createdUser);

            return response;
        }

        [Function("CreateUser")]
        public async Task<HttpResponseData> CreateUser([HttpTrigger(AuthorizationLevel.Function, "post", Route = "users")] HttpRequestData req, [FromBody] User user)
        {
            var createdUser = await _userRepo.CreateUser(user);
            
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(createdUser);
            return response;
        }
    }
}
