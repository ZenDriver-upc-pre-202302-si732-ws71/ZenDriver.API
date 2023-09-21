using ZenDriver.API.Security.Domain.Models;

namespace ZenDriver.API.DriverProfile.Resources;
public class DriverResource
{
    public int Id { get; set; }
    public User User { get; set; }

    public string startingYear { get; set; }
}
