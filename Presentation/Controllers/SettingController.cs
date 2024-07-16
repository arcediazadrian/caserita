using AutoMapper;
using Caserita_Domain.Entities;
using Caserita_Domain.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Caserita_Presentation.Controllers
{
    public class SettingController
    {
        private readonly ILogger _logger;
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;

        public SettingController(ILoggerFactory loggerFactory, ISettingService settingService, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<SettingController>();
            _settingService = settingService;
            _mapper = mapper;
        }

        [Function("CreateSetting")]
        public async Task<HttpResponseData> CreateSetting([HttpTrigger(AuthorizationLevel.Function, "post", Route = "settings")] HttpRequestData req, [FromBody] DTOs.Input.SettingDto dto)
        {
            var createdSetting = await _settingService.CreateSetting(_mapper.Map<Setting>(dto));

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(_mapper.Map<DTOs.Output.SettingDto>(createdSetting));
            return response;
        }

        [Function("GetSettingById")]
        public async Task<HttpResponseData> GetSettingById([HttpTrigger(AuthorizationLevel.Function, "get", Route = "settings/{id}")] HttpRequestData req, Guid id)
        {
            var setting = await _settingService.GetSettingById(id);
            if (setting == null)
            {
                var notFoundResponse = req.CreateResponse(HttpStatusCode.NotFound);
                return notFoundResponse;
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(_mapper.Map<DTOs.Output.SettingDto>(setting));
            return response;
        }

        [Function("GetAllSettings")]
        public async Task<HttpResponseData> GetAllSettings([HttpTrigger(AuthorizationLevel.Function, "get", Route = "settings")] HttpRequestData req)
        {
            var settings = await _settingService.GetAllSettings();

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(_mapper.Map<List<DTOs.Output.SettingDto>>(settings));
            return response;
        }

        [Function("UpdateSetting")]
        public async Task<HttpResponseData> UpdateSetting([HttpTrigger(AuthorizationLevel.Function, "put", Route = "settings/{id}")] HttpRequestData req, Guid id, [FromBody] DTOs.Input.SettingDto dto)
        {
            dto.Id = id;
            var updatedSetting = await _settingService.UpdateSetting(_mapper.Map<Setting>(dto));

            if (updatedSetting == null)
            {
                var notFoundResponse = req.CreateResponse(HttpStatusCode.NotFound);
                return notFoundResponse;
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(_mapper.Map<DTOs.Output.SettingDto>(updatedSetting));
            return response;
        }

        [Function("DeleteSetting")]
        public async Task<HttpResponseData> DeleteSetting([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "settings/{id}")] HttpRequestData req, Guid id)
        {
            var success = await _settingService.DeleteSetting(id);
            var response = req.CreateResponse(success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            return response;
        }
    }
}
