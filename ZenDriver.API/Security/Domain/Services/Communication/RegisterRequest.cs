using System.ComponentModel.DataAnnotations;
namespace ZenDriver.API.Security.Domain.Services.Communication;
public class RegisterRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Role { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required]
    public DateTime BirthdayDate { get; set; }
}