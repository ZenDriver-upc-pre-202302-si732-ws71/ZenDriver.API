using ZenDriver.API.Security.Domain.Models;

namespace ZenDriver.API.ApplyForJob.Resources;
public class AddressResource
{
    public int Id { get; set; }
    public string NameAddress { get; set; }
    public User User { get; set; }
}