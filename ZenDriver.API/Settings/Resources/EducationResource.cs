using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.Settings.Domain.Models;

namespace ZenDriver.API.Settings.Resources;
public class EducationResource
{
    public int Id { get; set; }
    public string Grade_education { get; set; }

    public DriverProfile.Domain.Models.DriverProfile DriverProfile { get; set; }

}
