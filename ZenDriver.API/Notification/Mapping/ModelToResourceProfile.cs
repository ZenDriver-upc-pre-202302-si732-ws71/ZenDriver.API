using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ZenDriver.API.Message.Resources;
using ZenDriver.API.Notification.Domain.Models;
using ZenDriver.API.Notification.Resources;
using ZenDriver.API.Settings.Domain.Models;
using ZenDriver.API.Settings.Resources;

namespace ZenDriver.API.Notification.Mapping;
public class ModelToResourceProfile :Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<NotificationZenDriver, NotificationResource>();
    }
}