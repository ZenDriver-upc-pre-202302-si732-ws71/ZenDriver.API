using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.Shared.Domain.Services.Communication;

namespace ZenDriver.API.DriverProfile.Domain.Services.Communication;
 public class DriverResponse : BaseResponse<Driver>
{
    public DriverResponse(string message) : base (message)
    {

    }

    public DriverResponse(Driver resource) : base (resource)
    {

    }
}