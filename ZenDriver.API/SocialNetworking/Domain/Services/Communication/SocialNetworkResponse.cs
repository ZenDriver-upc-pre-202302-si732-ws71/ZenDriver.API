using ZenDriver.API.Shared.Domain.Services.Communication;
using ZenDriver.API.SocialNetworking.Domain.Models;

namespace ZenDriver.API.SocialNetworking.Domain.Services.Communication;
public class SocialNetworkResponse : BaseResponse<SocialNetwork>
{
    public SocialNetworkResponse(string message) : base(message)
    {

    }

    public SocialNetworkResponse(SocialNetwork resource) : base(resource)
    {

    }
}