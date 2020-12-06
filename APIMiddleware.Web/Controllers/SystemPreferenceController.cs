using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Services.Interface;
using APIMiddleware.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIMiddleware.Web.Controllers
{
    public class SystemPreferenceController : Controller
    {
        private readonly ISystemPreferenceService _systemPreferenceService;

        public SystemPreferenceController(ISystemPreferenceService systemPreferenceService)
        {
            _systemPreferenceService = systemPreferenceService;
        }

        public IActionResult SystemSetting()
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

            return View(systemPreference);
        }

        [HttpPost]
        public IActionResult SystemPreferenceEditor(SystemPreferenceModel model)
        {
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

                _systemPreferenceService.UpdateSystemPreference(dto);
            }

            return View("SystemSetting", model);
        }
    }
}
