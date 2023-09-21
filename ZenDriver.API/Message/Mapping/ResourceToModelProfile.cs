using AutoMapper;
using ZenDriver.API.Message.Domain.Models;
using ZenDriver.API.Message.Resources;
using ZenDriver.API.Settings.Domain.Models;
using ZenDriver.API.Settings.Resources;

namespace ZenDriver.API.Message.Mapping;
public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveMessageResource, MessageZenDriver> ();
    }
}
