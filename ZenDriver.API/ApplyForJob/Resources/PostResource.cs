using ZenDriver.API.ApplyForJob.Domain.Models;

namespace ZenDriver.API.ApplyForJob.Resources;

public class PostResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime date { get; set; }
    public Recruiter Recruiter { get; set; }
}