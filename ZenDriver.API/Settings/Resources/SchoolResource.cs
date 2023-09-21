using ZenDriver.API.Settings.Domain.Models;

namespace ZenDriver.API.Settings.Resources;
public class SchoolResource
{
    public int Id { get; set; }
    public string name_school { get; set;}
    public string type { get; set; }

    public Education Education { get; set; }

    
}
