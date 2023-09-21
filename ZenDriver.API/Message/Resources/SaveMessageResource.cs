using System.ComponentModel.DataAnnotations;

namespace ZenDriver.API.Message.Resources;

public class SaveMessageResource
{
    [Required]
    public int EmitterId { get; set; }

    [Required]
    public int ReceiverId { get; set; }

    [Required]
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}