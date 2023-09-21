using ZenDriver.API.Security.Domain.Models;
using System.Text.Json.Serialization;
using ZenDriver.API.DriverProfile.Domain.Models;

namespace ZenDriver.API.Settings.Domain.Models;
public class Education
{
    public int Id { get; set; }
    public string Grade_education { get; set; }

    //Relationships
    public int DriverprofileId { get; set; }
    public DriverProfile.Domain.Models.DriverProfile DriverProfile { get; set; }

    [JsonIgnore]
    public IList<School> Schooles { get; set; } = new List<School>();
    
    
}
