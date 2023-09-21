using System.ComponentModel.DataAnnotations;

namespace ZenDriver.API.DriverProfile.Resources;

public class SaveDriverprofileResource
{
    [Required]
    public int DriverId { get; set; }
    [Required]
    public int LicenseId { get; set; }
}