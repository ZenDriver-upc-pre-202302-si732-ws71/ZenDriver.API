using System.Text.Json.Serialization;

namespace ZenDriver.API.ApplyForJob.Domain.Models;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string RUC { get; set; }
    public string Owner { get; set; }
    public string Image_url { get; set; }
    [JsonIgnore]
    public IList<Recruiter> Recruiters { get; set; }
}