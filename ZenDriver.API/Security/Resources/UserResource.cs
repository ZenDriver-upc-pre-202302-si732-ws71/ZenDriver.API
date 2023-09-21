using System.Text.Json.Serialization;

namespace ZenDriver.API.Security.Resources;

public class UserResource
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public DateTime BirthdayDate { get; set; }
}
