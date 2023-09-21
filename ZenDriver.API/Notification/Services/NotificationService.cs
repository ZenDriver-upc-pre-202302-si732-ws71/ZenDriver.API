using ZenDriver.API.Security.Domain.Repositories;
using ZenDriver.API.Shared.Domain.Repositories;
using ZenDriver.API.Notification.Domain.Models;
using ZenDriver.API.Notification.Domain.Repositories;
using ZenDriver.API.Notification.Domain.Services;
using ZenDriver.API.Notification.Domain.Services.Communication;

namespace ZenDriver.API.Notification.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    
    public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<NotificationZenDriver>> GetNotificationsAsync()
    {
        return await _notificationRepository.GetNotificationsAsync();
    }
    
    public async Task<NotificationResponse> AddNotificationAsync(NotificationZenDriver notification)
    {
        var existingUser = await _userRepository.FindByIdAsync(notification.EmitterId);

        if (existingUser == null)
            return new NotificationResponse("Invalid User");

        try
        {
            //Add Notification
            await _notificationRepository.AddNotificationAsync(notification);
            await _unitOfWork.CompleteAsync();

            //Return response
            return new NotificationResponse(notification);
        }
        catch (Exception e)
        {
            //Error Handling
            return new NotificationResponse($"An error ocurred while saving the tutorial: {e.Message}");
        }
    }
    
    public async Task<NotificationResponse> DeleteAsync(int id)
    {
        var existingNotification = await _notificationRepository.FindNotificationByIdAsync(id);
        
        if (existingNotification == null)
            return new NotificationResponse("Notification not found.");
        
        try
        {
            _notificationRepository.Remove(existingNotification);
            await _unitOfWork.CompleteAsync();
            
            return new NotificationResponse(existingNotification);
        }
        catch (Exception e)
        {
            return new NotificationResponse($"An error occurred when deleting the notification: {e.Message}");
        }
    }
}