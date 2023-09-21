using ZenDriver.API.Security.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ZenDriver.API.ApplyForJob.Resources;
public class SaveSocialNetworkResource
{ 

    [Required]
    public int UserId { get; set; }
    [MaxLength(500)]
    public string DescriptionSocialNetwork { get; set; }
    [MaxLength(500)]
    public string UrlImageSocialNetwork { get; set; }

    public int Like { get; set; } = 0;

}
