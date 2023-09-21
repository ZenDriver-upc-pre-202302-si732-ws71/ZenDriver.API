using System.ComponentModel.DataAnnotations;
using ZenDriver.API.Security.Domain.Models;

namespace ZenDriver.API.ApplyForJob.Resources;

public class SavePostResource
{
    [Required]
    public int RecruiterId { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public DateTime date { get; set; }
}