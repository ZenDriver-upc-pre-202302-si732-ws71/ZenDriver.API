using ZenDriver.API.DriverProfile.Domain.Models;

namespace ZenDriver.API.DriverProfile.Domain.Repositories;
public interface IDriverRepository
{
    Task<IEnumerable<Driver>> ListAsync();
    
    Task AddAsync(Driver driver);
    Task<Driver> FindByIdAsync(int id);
    void Update(Driver driver);
    void Remove(Driver driver);
}
