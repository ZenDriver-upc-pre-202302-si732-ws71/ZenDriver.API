
using ZenDriver.API.Message.Domain.Models;

namespace ZenDriver.API.Message.Domain.Repositories;

public interface IMessageRepository
{
    Task<IEnumerable<MessageZenDriver>> GetMessagesAsync();

    Task AddMessageAsync(MessageZenDriver message);

    Task<MessageZenDriver> FindMessageByIdAsync(int messageId);

    Task<IEnumerable<MessageZenDriver>> GetLastMessageRecruiter(int id);

    Task<IEnumerable<MessageZenDriver>> GetLastMessageDriver(int id);
    Task<IEnumerable<MessageZenDriver>?> GetMessagesByEmitterIdAsync(int emitterId);
    Task<IEnumerable<MessageZenDriver>?> GetMessagesByEmitterIdReceiverIdAsync(int emitterId, int receiverId);
    List<MessageZenDriver> GetLatestMessagesByReceiverIdAsync(int receiverId);
}