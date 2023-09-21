using ZenDriver.API.Notification.Domain.Models;

namespace ZenDriver.API.Notification.Domain.Repositories;

public interface INotificationRepository
{
    Task<IEnumerable<NotificationZenDriver>> GetNotificationsAsync();
    Task AddNotificationAsync(NotificationZenDriver notification);
    Task<NotificationZenDriver> FindNotificationByIdAsync(int notificationId);    
    void Remove(NotificationZenDriver notification);

}