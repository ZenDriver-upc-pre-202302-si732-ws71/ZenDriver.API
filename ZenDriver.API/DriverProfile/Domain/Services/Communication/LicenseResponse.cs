using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.Shared.Domain.Services.Communication;

namespace ZenDriver.API.DriverProfile.Domain.Services.Communication;
 public class LicenseResponse : BaseResponse<License>
{
    public LicenseResponse(string message) : base (message)
    {

    }

    public LicenseResponse(License resource) : base (resource)
    {

    }
}