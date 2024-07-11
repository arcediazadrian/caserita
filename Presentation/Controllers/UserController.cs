using AutoMapper;
using Caserita_Domain.Entities;
using Caserita_Domain.Exceptions;
using Caserita_Domain.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Caserita_Presentation.Controllers
{
    public class UserController
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(ILoggerFactory loggerFactory, IUserService userService, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<UserController>();
            _userService = userService;
            _mapper = mapper;
        }

        [Function("CreateUser")]
        public async Task<HttpResponseData> CreateUser([HttpTrigger(AuthorizationLevel.Function, "post", Route = "users")] HttpRequestData req, [FromBody] DTOs.Input.UserDto dto)
        {
            var createdUser = await _userService.CreateUser(_mapper.Map<User>(dto));

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(_mapper.Map<DTOs.Output.UserDto>(createdUser));
            return response;
        }

        [Function("ThrowException")]
        public HttpResponseData ThrowException([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "ThrowException/{identifier?}")] HttpRequestData req, int identifier = 0)
        {
            if (identifier == 1)
            {
                throw new InvalidInputException("Double send on Integer value");
            }
            else
            {
                throw new Exception("It failed");
            }

        }
    }
}
