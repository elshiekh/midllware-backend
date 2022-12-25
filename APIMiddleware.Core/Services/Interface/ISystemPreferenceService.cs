using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Entities;
using APIMiddleware.Notification.Models;

namespace APIMiddleware.Core.Services.Interface
{
    public interface ISystemPreferenceService
    {
        SystemPreference GetSystemPreference(int id);
        SystemPreferenceDTO InitiateSystemPreferenceDTO();
        bool UpdateSystemPreference(SystemPreferenceDTO model);
        SystemPreferenceDTO GetSystemPreferences();
        NotificationMetadata GetNotificationMetadata();
    }
}
