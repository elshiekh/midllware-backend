using APIMiddleware.Core.DBContext;
using APIMiddleware.Core.Entities;
using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Services.Interface;
using APIMiddleware.Notification.Models;
using System;
using System.Linq;
using static APIMiddleware.Core.DTO.SystemEnums;

namespace APIMiddleware.Core.Services.Implementation
{
    public class SystemPreferenceService : ISystemPreferenceService
    {
        private readonly APIMiddlewareContext _dbContext;

        public SystemPreferenceService() {
            _dbContext = new APIMiddlewareContext();
        }

        public SystemPreference GetSystemPreference(int id) => _dbContext.SystemPreferences.FirstOrDefault(s => s.PreferenceId == id);

        public SystemPreferenceDTO InitiateSystemPreferenceDTO()
        {
            var model = new SystemPreferenceDTO();
            FillPreferenceModel(model);

            return model;
        }

        private void FillPreferenceModel(SystemPreferenceDTO model)
        {
            var systemPreferenceList = _dbContext.SystemPreferences.ToList();
            int parseVar;

            foreach (var item in systemPreferenceList)
            {
                switch (item.PreferenceId)
                {
                    case (int)PreferenceCode.FaildedAPI:
                        int.TryParse(item.PreferenceValue, out parseVar);
                        model.FaildedAPI = parseVar;
                        break;
                    case (int)PreferenceCode.FaildedAPITime:
                        int.TryParse(item.PreferenceValue, out parseVar);
                        model.FaildedAPITime = parseVar;
                        break;
                    case (int)PreferenceCode.FaildedAPICount:
                        int.TryParse(item.PreferenceValue, out parseVar);
                        model.FaildedAPICount = parseVar;
                        break;
                    case (int)PreferenceCode.EmailBody:
                        int.TryParse(item.PreferenceValue, out parseVar);
                        model.EmailBody = item.PreferenceValue;
                        break;
                    case (int)PreferenceCode.EmailSubject:
                        model.EmailSubject = item.PreferenceValue;
                        break;
                    case (int)PreferenceCode.EmailUserName:
                        model.EmailUserName = item.PreferenceValue;
                        break;
                    case (int)PreferenceCode.EmailPassword:
                        model.EmailPassword = item.PreferenceValue;
                        break;
                    case (int)PreferenceCode.EmailServerPort:
                        int.TryParse(item.PreferenceValue, out parseVar);
                        model.EmailServerPort = parseVar;
                        break;
                    case (int)PreferenceCode.EmailReciever:
                        model.EmailReciever = item.PreferenceValue;
                        break;
                    case (int)PreferenceCode.EmailSender:
                        model.EmailSender = item.PreferenceValue;
                        break;
                    case (int)PreferenceCode.EmailSmtpServer:
                        model.EmailSmtpServer = item.PreferenceValue;
                        break;
                }
            }
        }

        public bool UpdateSystemPreference(SystemPreferenceDTO model)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var systemPreferences = _dbContext.SystemPreferences.ToList();
                var faildedAPI = systemPreferences.FirstOrDefault(x => x.PreferenceId == (int)PreferenceCode.FaildedAPI);
                var faildedAPITime = systemPreferences.FirstOrDefault(x => x.PreferenceId == (int)PreferenceCode.FaildedAPITime);
                var faildedAPICount = systemPreferences.FirstOrDefault(x => x.PreferenceId == (int)PreferenceCode.FaildedAPICount);
                var emailBody = systemPreferences.FirstOrDefault(x => x.PreferenceId == (int)PreferenceCode.EmailBody);
                var emailSubject = systemPreferences.FirstOrDefault(x => x.PreferenceId == (int)PreferenceCode.EmailSubject);

                var userName = systemPreferences.FirstOrDefault(x => x.PreferenceId == (int)PreferenceCode.EmailUserName);
                var password = systemPreferences.FirstOrDefault(x => x.PreferenceId == (int)PreferenceCode.EmailPassword);
                var reciever = systemPreferences.FirstOrDefault(x => x.PreferenceId == (int)PreferenceCode.EmailReciever);
                var sender = systemPreferences.FirstOrDefault(x => x.PreferenceId == (int)PreferenceCode.EmailSender);
                var serverPort = systemPreferences.FirstOrDefault(x => x.PreferenceId == (int)PreferenceCode.EmailServerPort);
                var smtpServer = systemPreferences.FirstOrDefault(x => x.PreferenceId == (int)PreferenceCode.EmailSmtpServer);


                if (faildedAPI.PreferenceValue != model.FaildedAPI.ToString())
                {
                    faildedAPI.PreferenceValue = model.FaildedAPI.ToString();
                    _dbContext.Update(faildedAPI);
                }                
                
                if (smtpServer.PreferenceValue != model.EmailSmtpServer.ToString())
                {
                    smtpServer.PreferenceValue = model.EmailSmtpServer.ToString();
                    _dbContext.Update(smtpServer);
                }

                if (password.PreferenceValue != model.FaildedAPI.ToString())
                {
                    password.PreferenceValue = model.EmailPassword.ToString();
                    _dbContext.Update(password);
                }                
                
                if (reciever.PreferenceValue != model.EmailReciever.ToString())
                {
                    reciever.PreferenceValue = model.EmailReciever.ToString();
                    _dbContext.Update(reciever);
                }                
                
                if (sender.PreferenceValue != model.EmailSender.ToString())
                {
                    sender.PreferenceValue = model.EmailSender.ToString();
                    _dbContext.Update(sender);
                }                
                
                if (serverPort.PreferenceValue != model.EmailServerPort.ToString())
                {
                    serverPort.PreferenceValue = model.EmailServerPort.ToString();
                    _dbContext.Update(serverPort);
                }

                if (userName.PreferenceValue != model.EmailUserName.ToString())
                {
                    userName.PreferenceValue = model.EmailUserName.ToString();
                    _dbContext.Update(userName);
                }

                if (faildedAPICount.PreferenceValue != model.FaildedAPICount.ToString())
                {
                    faildedAPICount.PreferenceValue = model.FaildedAPICount.ToString();
                    _dbContext.Update(faildedAPICount);
                }

                if (emailBody.PreferenceValue != model.EmailBody.ToString())
                {
                    emailBody.PreferenceValue = model.EmailBody.ToString();
                    _dbContext.Update(emailBody);
                }

                if (emailSubject.PreferenceValue != model.EmailSubject.ToString())
                {
                    emailSubject.PreferenceValue = model.EmailSubject.ToString();
                    _dbContext.Update(emailSubject);
                }

                _dbContext.SaveChanges();
                transaction.Commit();

                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }

        }

        public SystemPreferenceDTO GetSystemPreferences()
        {
            var model = new SystemPreferenceDTO();
            FillPreferenceModel(model);

            return model;
        }

        public NotificationMetadata GetNotificationMetadata()
        {
            var model = new SystemPreferenceDTO();
            FillPreferenceModel(model);

            return new NotificationMetadata
            {
                UserName = model.EmailUserName,
                Password = model.EmailPassword,
                Port = model.EmailServerPort,
                Reciever = model.EmailReciever,
                Sender = model.EmailSender,
                SmtpServer = model.EmailSmtpServer,
            };
        }
    }
}
