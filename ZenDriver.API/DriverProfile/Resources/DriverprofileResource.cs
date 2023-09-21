using ZenDriver.API.DriverProfile.Domain.Models;

namespace ZenDriver.API.DriverProfile.Resources;

public class DriverprofileResource
{
    public int Id { get; set; }
    

    public Driver Driver { get; set; }

    public License License { get; set; }
}