using ZenDriver.API.Notification.Domain.Models;
using ZenDriver.API.Notification.Domain.Services.Communication;

namespace ZenDriver.API.Notification.Domain.Services;

public interface INotificationService
{
    Task<IEnumerable<NotificationZenDriver>> GetNotificationsAsync();
    Task<NotificationResponse> AddNotificationAsync(NotificationZenDriver notification);    
    Task<NotificationResponse> DeleteAsync(int id);

}