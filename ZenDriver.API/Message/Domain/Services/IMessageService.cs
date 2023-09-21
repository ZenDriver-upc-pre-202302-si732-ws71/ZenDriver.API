using ZenDriver.API.Message.Domain.Models;
using ZenDriver.API.Message.Domain.Services.Communication;
using ZenDriver.API.Security.Domain.Models;

namespace ZenDriver.API.Message.Domain.Services;

public interface IMessageService
{     
    Task<IEnumerable<MessageZenDriver>> GetMessagesAsync();

    Task<MessageResponse> AddMessageAsync(MessageZenDriver message);
    Task<IEnumerable<MessageZenDriver>?> GetMessagesByEmitterIdAsync(int emitterId);
    Task<IEnumerable<MessageZenDriver>?> GetMessagesByEmitterReceiverIdAsync(int emitterId, int receiverId);
    List<MessageZenDriver> GetLatestMessagesByReceiverIdAsync(int receiverId);
    Task<User?> FindReceiverByIdAsync(int resourceReceiverId);
}