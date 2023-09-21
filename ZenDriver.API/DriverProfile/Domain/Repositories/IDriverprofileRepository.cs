using ZenDriver.API.DriverProfile.Domain.Models;

namespace ZenDriver.API.DriverProfile.Domain.Repositories;
public interface IDriverprofileRepository
{
    Task<IEnumerable<Models.DriverProfile>> ListAsync();
    Task AddAsync(Models.DriverProfile driverProfile);
    Task<Models.DriverProfile> FindByIdAsync(int id);
    void Update(Models.DriverProfile driverProfile);
    void Remove(Models.DriverProfile driverProfile);
}
