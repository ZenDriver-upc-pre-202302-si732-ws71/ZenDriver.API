using AutoMapper;
using ZenDriver.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using ZenDriver.API.Notification.Domain.Models;
using ZenDriver.API.Notification.Domain.Services;
using ZenDriver.API.Notification.Resources;

namespace ZenDriver.API.Notification.Controllers;

[ApiController]
[Route("api/v1/[controller]/{userid}")]
public class NotificationController: ControllerBase
{
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;
    
    public NotificationController(INotificationService notificationService, IMapper mapper)
    {
        _notificationService = notificationService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<NotificationResource>> GetAllNotificationsAsync(int userid)
    {
        var notifications = await _notificationService.GetNotificationsAsync();
        var resources = _mapper.Map<IEnumerable<NotificationZenDriver>, IEnumerable<NotificationResource>>(notifications);
        resources = resources.Where(x => (x.Receiver.Id == userid) ).ToList();
        return resources;
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddNotificationAsync([FromBody] SaveNotificationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var notification = _mapper.Map<SaveNotificationResource, NotificationZenDriver>(resource);

        var result = await _notificationService.AddNotificationAsync(notification);

        if (!result.Success)
            return BadRequest(result.Message);

        var notificationResource = _mapper.Map<NotificationZenDriver, NotificationResource>(result.Resource);

        return Ok(notificationResource);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _notificationService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var notificationResource = _mapper.Map<NotificationZenDriver, NotificationResource>(result.Resource);
        return Ok(notificationResource);
    }
    
}