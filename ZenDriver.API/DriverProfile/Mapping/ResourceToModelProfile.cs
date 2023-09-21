using AutoMapper;
using ZenDriver.API.DriverProfile.Resources;
using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.DriverProfile.Resources;

namespace ZenDriver.API.DriverProfile.Mapping;
public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveDriverResource, Driver> ();
        CreateMap<SaveDriverprofileResource, Domain.Models.DriverProfile> ();
        CreateMap<SaveLicenseResource, License> ();
    }
}
