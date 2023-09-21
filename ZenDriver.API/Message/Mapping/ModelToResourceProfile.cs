using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ZenDriver.API.Message.Domain.Models;
using ZenDriver.API.Message.Resources;
using ZenDriver.API.Settings.Domain.Models;
using ZenDriver.API.Settings.Resources;

namespace ZenDriver.API.Message.Mapping;
public class ModelToResourceProfile :Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<MessageZenDriver, MessageResource>();
    }
}