using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.Shared.Domain.Services.Communication;

namespace ZenDriver.API.DriverProfile.Domain.Services.Communication;
 public class DriverprofileResponse : BaseResponse<Models.DriverProfile>
{
    public DriverprofileResponse(string message) : base (message)
    {

    }

    public DriverprofileResponse(Models.DriverProfile resource) : base (resource)
    {

    }
}