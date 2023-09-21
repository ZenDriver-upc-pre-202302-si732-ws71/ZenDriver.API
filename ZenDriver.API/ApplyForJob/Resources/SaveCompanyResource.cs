using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.Security.Domain.Models;

namespace ZenDriver.API.ApplyForJob.Resources;

public class SaveCompanyResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string RUC { get; set; }
    public string Owner { get; set; }
    public Recruiter Recruiter { get; set; }
}