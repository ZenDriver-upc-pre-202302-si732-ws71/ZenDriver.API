using ZenDriver.API.Shared.Domain.Services.Communication;
using ZenDriver.API.Settings.Domain.Models;

namespace ZenDriver.API.Settings.Domain.Services.Communication;
 public class EducationResponse : BaseResponse<Education>
{
    public EducationResponse(string message) : base (message)
    {

    }

    public EducationResponse(Education resource) : base (resource)
    {

    }
}