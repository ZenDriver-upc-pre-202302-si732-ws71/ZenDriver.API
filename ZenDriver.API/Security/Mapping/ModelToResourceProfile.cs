using AutoMapper;
using ZenDriver.API.Security.Domain.Models;
using ZenDriver.API.Security.Domain.Services.Communication;
using ZenDriver.API.Security.Resources;

namespace ZenDriver.API.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();

        CreateMap<User, UserResource>();
    }
}
