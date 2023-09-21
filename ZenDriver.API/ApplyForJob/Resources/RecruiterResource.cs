using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.Security.Domain.Models;

namespace ZenDriver.API.ApplyForJob.Resources;

public class RecruiterResource
{
    public int Id { get; set; }
    public User User { get; set; }
    public Company Company { get; set; }
    public IEnumerable<Post> Posts { get; set; }
}