using ZenDriver.API.Security.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ZenDriver.API.Notification.Resources;

public class SaveNotificationResource
{
    [Required]
    public int EmitterId { get; set; }
    
    [Required]
    public int ReceiverId { get; set; }
    
    [Required]
    public string Content { get; set; }
}