using ZenDriver.API.Security.Domain.Models;
using System.Text.Json.Serialization;

namespace ZenDriver.API.SocialNetworking.Domain.Models;
public class SocialNetwork
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string DescriptionSocialNetwork { get; set; }
    public string UrlImageSocialNetwork { get; set; }
    
    public int Like { get; set; } = 0;

    //Relationships
    public User User { get; set; }
}
