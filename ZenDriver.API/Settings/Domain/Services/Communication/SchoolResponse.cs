using ZenDriver.API.Shared.Domain.Services.Communication;
using ZenDriver.API.Settings.Domain.Models;

namespace ZenDriver.API.Settings.Domain.Services.Communication;
 public class SchoolResponse : BaseResponse<School>
{
    public SchoolResponse(string message) : base (message)
    {

    }

    public SchoolResponse(School resource) : base (resource)
    {

    }
}