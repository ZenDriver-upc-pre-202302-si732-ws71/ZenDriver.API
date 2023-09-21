using AutoMapper;
using ZenDriver.API.DriverProfile.Resources;
using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.DriverProfile.Resources;
using ZenDriver.API.SocialNetworking.Domain.Models;
using ZenDriver.API.SocialNetworking.Resources;

namespace ZenDriver.API.SocialNetworking.Mapping;
public class ModelToResourceProfile :Profile
{
    public ModelToResourceProfile()
    {
        
        CreateMap<SocialNetwork, SocialNetworkResource>();
    }
}