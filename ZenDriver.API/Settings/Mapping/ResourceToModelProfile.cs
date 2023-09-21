using AutoMapper;
using ZenDriver.API.Settings.Domain.Models;
using ZenDriver.API.Settings.Resources;

namespace ZenDriver.API.Settings.Mapping;
public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveEducationResource, Education> ();
        CreateMap<SaveSchoolResource, School> ();
    }
}
