namespace ZenDriver.API.ApplyForJob.Domain.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime date { get; set; }
    public int RecruiterId { get; set; }
    public Recruiter Recruiter { get; set; }
}