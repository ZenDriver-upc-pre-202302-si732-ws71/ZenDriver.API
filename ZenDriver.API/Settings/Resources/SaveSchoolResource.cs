using System.ComponentModel.DataAnnotations;

namespace ZenDriver.API.Settings.Resources;
public class SaveSchoolResource
{
    

    [Required]
    [MaxLength(50)]
    public string name_school { get; set;}
    [Required]
    [MaxLength(50)]
    public string type { get; set; }
    [Required]
    public int EducationId { get; set; }


    
}