using APIMiddleware.API.Models;
using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIMiddleware.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemPreferenceController : ControllerBase
    {
        private readonly ISystemPreferenceService _systemPreferenceService;

        public SystemPreferenceController(ISystemPreferenceService systemPreferenceService)
        {
            _systemPreferenceService = systemPreferenceService;
        }

        [HttpGet]
        public  IActionResult SystemSetting()
        {
            var model = _systemPreferenceService.InitiateSystemPreferenceDTO();
            var systemPreference = new SystemPreferenceModel
            {
                PreferenceId = model.PreferenceId,
                PreferenceCode = model.PreferenceCode,
                FaildedAPI = model.FaildedAPI,
                FaildedAPITime = model.FaildedAPITime,
                FaildedAPICount = model.FaildedAPICount,
                EmailSubject = model.EmailSubject,
                EmailBody = model.EmailBody,
                EmailUserName = model.EmailUserName,
                EmailPassword = model.EmailPassword,
                EmailReciever = model.EmailReciever,
                EmailSender = model.EmailSender,
                EmailServerPort = model.EmailServerPort,
                EmailSmtpServer = model.EmailSmtpServer,
            };

            return Ok(systemPreference);
        }

        [HttpPut]
        public IActionResult SystemPreferenceEditor(SystemPreferenceModel model)
        {
            var result = new SystemPreferenceResponse();
            if (ModelState.IsValid)
            {
                var dto = new SystemPreferenceDTO()
                {
                    PreferenceId = model.PreferenceId,
                    PreferenceCode = model.PreferenceCode,
                    FaildedAPI = model.FaildedAPI,
                    FaildedAPITime = model.FaildedAPITime,
                    FaildedAPICount = model.FaildedAPICount,
                    EmailSubject = model.EmailSubject,
                    EmailBody = model.EmailBody,
                    EmailUserName = model.EmailUserName,
                    EmailPassword = model.EmailPassword,
                    EmailReciever = model.EmailReciever,
                    EmailSender = model.EmailSender,
                    EmailServerPort = model.EmailServerPort,
                    EmailSmtpServer = model.EmailSmtpServer,
                };

            var IsUpdated= _systemPreferenceService.UpdateSystemPreference(dto);
              result = new SystemPreferenceResponse
                {
                    data = model,
                    Status = "success",
                    Message = "Updated Successfully"
                };
            }

            return Ok(result);
        }
    }
}
