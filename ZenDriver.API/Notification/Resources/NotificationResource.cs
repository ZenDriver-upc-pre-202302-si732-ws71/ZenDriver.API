using ZenDriver.API.Security.Domain.Models;

namespace ZenDriver.API.Notification.Resources;

public class NotificationResource
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime date { get; set; }
    
    //Relationships
    public User Emitter { get; set; }
    public User Receiver { get; set; }
}