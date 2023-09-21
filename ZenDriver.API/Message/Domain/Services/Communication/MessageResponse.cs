using ZenDriver.API.Message.Domain.Models;
using ZenDriver.API.Shared.Domain.Services.Communication;

namespace ZenDriver.API.Message.Domain.Services.Communication;

 public class MessageResponse : BaseResponse<MessageZenDriver>
{
    public MessageResponse(string message) : base(message)
    {

    }

    public MessageResponse(MessageZenDriver resource) : base(resource)
    {

    }
}
