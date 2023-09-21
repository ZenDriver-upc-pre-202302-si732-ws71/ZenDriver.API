using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.ApplyForJob.Domain.Services.Communication;

namespace ZenDriver.API.ApplyForJob.Domain.Services;
public interface IAddressService
{
    Task<IEnumerable<Address>> ListAsync();
    Task<IEnumerable<Address>> ListByUserIdAsync(int userId);
    Task<AddressResponse> SaveAsync(Address address);
    Task<AddressResponse> UpdateAsync(int userId, Address address);
    Task<AddressResponse> DeleteAsync(int userId);
}
