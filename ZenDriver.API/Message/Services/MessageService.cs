using ZenDriver.API.Message.Domain.Models;
using ZenDriver.API.Message.Domain.Repositories;
using ZenDriver.API.Message.Domain.Services;
using ZenDriver.API.Message.Domain.Services.Communication;
using ZenDriver.API.Security.Domain.Models;
using ZenDriver.API.Security.Domain.Repositories;
using ZenDriver.API.Shared.Domain.Repositories;

namespace ZenDriver.API.Message.Services;
public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _messageRepository = messageRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<MessageZenDriver>> GetMessagesAsync()
    {
        return await _messageRepository.GetMessagesAsync();
    }

    public async Task<MessageResponse> AddMessageAsync(MessageZenDriver message)
    {
        var existingUser = await _userRepository.FindByIdAsync(message.EmitterId);

        if (existingUser == null)
            return new MessageResponse("Invalid User");

        try
        {
            //Add Message
            await _messageRepository.AddMessageAsync(message);
            await _unitOfWork.CompleteAsync();

            //Return response
            return new MessageResponse(message);
        }
        catch (Exception e)
        {
            //Error Handling
            return new MessageResponse($"An error ocurred while saving the tutorial: {e.Message}");
        }
    }

    public async Task<IEnumerable<MessageZenDriver>?> GetMessagesByEmitterIdAsync(int emitterId)
    {
        try
        {
            return await _messageRepository.GetMessagesByEmitterIdAsync(emitterId);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<MessageZenDriver>?> GetMessagesByEmitterReceiverIdAsync(int emitterId, int receiverId)
    {
        try
        {
            return await _messageRepository.GetMessagesByEmitterIdReceiverIdAsync(emitterId, receiverId);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public List<MessageZenDriver> GetLatestMessagesByReceiverIdAsync(int receiverId)
    {
        return _messageRepository.GetLatestMessagesByReceiverIdAsync(receiverId);
    }

    public Task<User?> FindReceiverByIdAsync(int resourceReceiverId)
    {
        return _userRepository.FindByIdAsync(resourceReceiverId);
    }
}


