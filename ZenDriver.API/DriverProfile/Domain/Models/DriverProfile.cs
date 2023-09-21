using ZenDriver.API.Settings.Domain.Models;

namespace ZenDriver.API.DriverProfile.Domain.Models;
public class DriverProfile
{
    public int Id { get; set; }
    

    //Relationships
    public int DriverId { get; set; }
    public Driver Driver { get; set; }

    public int LicenseId { get; set; }
    public License License { get; set; }
    public Education Education { get; set; }
}