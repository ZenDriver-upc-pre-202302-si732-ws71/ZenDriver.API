using System.ComponentModel.DataAnnotations;

namespace ZenDriver.API.DriverProfile.Resources;
public class SaveLicenseResource
{
    [Required]
    [MaxLength(50)]
    public string Category { get;set;}
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }


}
