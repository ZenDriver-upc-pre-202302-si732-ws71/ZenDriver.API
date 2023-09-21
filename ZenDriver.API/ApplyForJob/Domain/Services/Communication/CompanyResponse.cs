using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.Shared.Domain.Services.Communication;

namespace ZenDriver.API.ApplyForJob.Domain.Services.Communication;

public class CompanyResponse : BaseResponse<Company>
{
    public CompanyResponse(Company resource) : base(resource)
    {
    }
    
    public CompanyResponse(string message) : base(message)
    {
    }
}