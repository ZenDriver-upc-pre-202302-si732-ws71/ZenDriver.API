using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.Shared.Domain.Services.Communication;

namespace ZenDriver.API.ApplyForJob.Domain.Services.Communication;

public class PostResponse : BaseResponse<Post>
{
    public PostResponse(Post resource) : base(resource)
    {
    }
    
    public PostResponse(string message) : base(message)
    {
    }
}