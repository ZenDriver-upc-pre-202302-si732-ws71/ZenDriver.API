using ZenDriver.API.Shared.Domain.Services.Communication;
using ZenDriver.API.Notification.Domain.Models;

namespace ZenDriver.API.Notification.Domain.Services.Communication;

public class NotificationResponse : BaseResponse<NotificationZenDriver>

{
    public NotificationResponse(string notification) : base(notification)
    {
    }
    
    public NotificationResponse(NotificationZenDriver resource) : base(resource)
    {
    }
}