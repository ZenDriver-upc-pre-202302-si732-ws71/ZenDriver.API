using ZenDriver.API.ApplyForJob.Domain.Models;

namespace ZenDriver.API.ApplyForJob.Domain.Repositories;
public interface IAddressRepository
{
    Task<IEnumerable<Address>> ListAsync();
    Task AddAsync(Address address);
    Task<Address> FindByIdAsync(int addressId);
    Task<Address> FindByNameAddressAsync(string addressName);
    Task<IEnumerable<Address>> FindByUserIdAsyn(int userId);
    void Update(Address address);
    void Remove(Address address);
}
