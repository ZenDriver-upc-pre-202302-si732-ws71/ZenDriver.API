using System.ComponentModel.DataAnnotations;

namespace ZenDriver.API.Settings.Resources;
public class SaveEducationResource
{

    [Required]
    [MaxLength(500)]
    public string Grade_education { get; set; }
    
    [Required]
    public int DriverprofileId { get; set; }

}