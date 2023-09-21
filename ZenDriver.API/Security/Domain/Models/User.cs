using System.Text.Json.Serialization;
using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.Message.Domain.Models;
using ZenDriver.API.Notification.Domain.Models;
using ZenDriver.API.SocialNetworking.Domain.Models;

namespace ZenDriver.API.Security.Domain.Models;
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public DateTime BirthdayDate { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }

    [JsonIgnore]
    public IList<SocialNetwork> SocialNetworks { get; set; } = new List<SocialNetwork>();

    [JsonIgnore]
    public IList<Address> Addresses { get; set; } = new List<Address>();

    [JsonIgnore]
    public IList<MessageZenDriver> EmittedMessages { get; set; } = new List<MessageZenDriver>();

    [JsonIgnore]
    public IList<MessageZenDriver> ReceivedMessages { get; set; } = new List<MessageZenDriver>();
    
    [JsonIgnore]
    public IList<Address> Address { get; set; } = new List<Address>();
    [JsonIgnore]
    public IList<NotificationZenDriver> EmittedNotifications { get; set; } = new List<NotificationZenDriver>();
    
    [JsonIgnore]
    public IList<NotificationZenDriver> ReceivedNotifications { get; set; } = new List<NotificationZenDriver>();
    [JsonIgnore]
    public Driver Driver { get; set; } 
    [JsonIgnore]
    public Recruiter Recruiter { get; set; }

}