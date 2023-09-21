using ZenDriver.API.Security.Domain.Models;

namespace ZenDriver.API.Message.Domain.Models;

    public class MessageZenDriver
    {
        
        public int Id { get; set; }
        public string Content { get; set; }
        public int EmitterId { get; set; }
        public User Emitter { get; set; }

        public int ReceiverId { get; set; }
        public User Receiver { get; set; }
        public DateTime CreatedAt { get; set; }
    }