using AutoMapper;
using ZenDriver.API.Message.Domain.Models;
using ZenDriver.API.Message.Domain.Services;
using ZenDriver.API.Message.Resources;
using ZenDriver.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ZenDriver.API.Message.Controllers;

[Route("/api/v1/[controller]")]
    
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;
    
    public MessageController(IMessageService messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<MessageResource>> GetAllMessagesAsync()
    {
        var messages = await _messageService.GetMessagesAsync();
        var resources = _mapper.Map<IEnumerable<MessageZenDriver>, IEnumerable<MessageResource>>(messages);

        return resources;
    }
    [HttpGet("search-last-messages-receiver-id/{receiverId}")]
    public IEnumerable<MessageResource> GetLatestMessagesByReceiverIdAsync(int receiverId)
    {
        var messages = _messageService.GetLatestMessagesByReceiverIdAsync(receiverId);
        var resources = _mapper.Map<IEnumerable<MessageZenDriver>, IEnumerable<MessageResource>>(messages);

        return resources;
    }
    
    [HttpGet("search-by-id/{emitterId}")]
    public async Task<IEnumerable<MessageResource>> GetMessagesByEmitterIdAsync(int emitterId)
    {
        var messages = await _messageService.GetMessagesByEmitterIdAsync(emitterId);
        var resources = _mapper.Map<IEnumerable<MessageZenDriver>, IEnumerable<MessageResource>>(messages);

        return resources;
    }
    [HttpGet("search-by-emitter-receiver/{emitterId}/{receiverId}")]
    public async Task<IEnumerable<MessageResource>?> GetMessagesByEmitterReceiverIdAsync(int emitterId, int receiverId)
    {
        var messages = await _messageService.GetMessagesByEmitterReceiverIdAsync(emitterId, receiverId);
        if (messages == null) return null;
        var resources = _mapper.Map<IEnumerable<MessageZenDriver>, IEnumerable<MessageResource>>(messages);

        return resources;
    }
    
    [HttpPost("add-message")]
    public async Task<IActionResult> AddMessageAsync([FromBody] SaveMessageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        resource.CreatedAt = DateTime.Now;

        var message = _mapper.Map<SaveMessageResource, MessageZenDriver>(resource);
        message.Receiver = await _messageService.FindReceiverByIdAsync(resource.ReceiverId);
        var result = await _messageService.AddMessageAsync(message);

        if (!result.Success)
            return BadRequest(result.Message);

        var messageResource = _mapper.Map<MessageZenDriver, MessageResource>(result.Resource);
        

        return Ok(messageResource);
    }
}

