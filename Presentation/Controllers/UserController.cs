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

        [Function("GetUserById")]
        public async Task<HttpResponseData> GetUserById([HttpTrigger(AuthorizationLevel.Function, "get", Route = "users/{id}")] HttpRequestData req, Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                var notFoundResponse = req.CreateResponse(HttpStatusCode.NotFound);
                return notFoundResponse;
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(_mapper.Map<DTOs.Output.UserDto>(user));
            return response;
        }

        [Function("GetAllUsers")]
        public async Task<HttpResponseData> GetAllUsers([HttpTrigger(AuthorizationLevel.Function, "get", Route = "users")] HttpRequestData req)
        {
            var users = await _userService.GetAllUsers();

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(_mapper.Map<List<DTOs.Output.UserDto>>(users));
            return response;
        }

        [Function("UpdateUser")]
        public async Task<HttpResponseData> UpdateUser([HttpTrigger(AuthorizationLevel.Function, "put", Route = "users/{id}")] HttpRequestData req, Guid id, [FromBody] DTOs.Input.UserDto dto)
        {
            dto.Id = id;
            var updatedUser = await _userService.UpdateUser(_mapper.Map<User>(dto));

            if (updatedUser == null)
            {
                var notFoundResponse = req.CreateResponse(HttpStatusCode.NotFound);
                return notFoundResponse;
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(_mapper.Map<DTOs.Output.UserDto>(updatedUser));
            return response;
        }

        [Function("DeleteUser")]
        public async Task<HttpResponseData> DeleteUser([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "users/{id}")] HttpRequestData req, Guid id)
        {
            var success = await _userService.DeleteUser(id);
            var response = req.CreateResponse(success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
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
