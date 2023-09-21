namespace ZenDriver.API.Settings.Domain.Models;
public class School
{
    public int Id { get; set; }
    public string name_school { get; set;}
    public string type { get; set; }

    //Relationships
    public int EducationId { get; set; }
    public Education Education { get; set; }

    
}
