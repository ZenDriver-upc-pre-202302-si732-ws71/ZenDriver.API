using ZenDriver.API.Security.Domain.Models;

namespace ZenDriver.API.SocialNetworking.Resources;
public class SocialNetworkResource
{
    public int Id { get; set; }
    public string DescriptionSocialNetwork { get; set; }
    public string UrlImageSocialNetwork { get; set; }

    public int Like { get; set; } = 0;

    //Relationships
    public User User { get; set; }
}
