using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.Shared.Domain.Services.Communication;

namespace ZenDriver.API.ApplyForJob.Domain.Services.Communication;

public class RecruiterResponse : BaseResponse<Recruiter>
{
    protected RecruiterResponse(string message) : base(message)
    {
    }

    protected RecruiterResponse(Recruiter resource) : base(resource)
    {
    }
}