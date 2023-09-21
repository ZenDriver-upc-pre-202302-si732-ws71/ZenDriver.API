using System.Text.Json.Serialization;
using ZenDriver.API.Security.Domain.Models;

namespace ZenDriver.API.DriverProfile.Domain.Models;
public class Driver
{
    public int Id { get; set; }

    //Relationships
    public int UserId { get; set; }
    public User User { get; set; }
    public String startingYear { get; set; }
    [JsonIgnore]
    public DriverProfile DriverProfile { get; set; }
}
