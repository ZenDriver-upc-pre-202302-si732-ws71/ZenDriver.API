using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.Shared.Domain.Services.Communication;

namespace ZenDriver.API.ApplyForJob.Domain.Services.Communication;
 public class AddressResponse : BaseResponse<Address>
{
    public AddressResponse(string message) : base (message)
    {

    }

    public AddressResponse(Address resource) : base (resource)
    {

    }
}