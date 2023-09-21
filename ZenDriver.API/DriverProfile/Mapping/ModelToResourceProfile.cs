using AutoMapper;
using ZenDriver.API.DriverProfile.Resources;
using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.DriverProfile.Resources;

namespace ZenDriver.API.DriverProfile.Mapping;
public class ModelToResourceProfile :Profile
{
    public ModelToResourceProfile()
    {
        
        CreateMap<Driver, DriverResource>();
        CreateMap<Domain.Models.DriverProfile, DriverprofileResource>();
        CreateMap<License, LicenseResource>();
    }
}