using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.DriverProfile.Domain.Services.Communication;

namespace ZenDriver.API.DriverProfile.Domain.Services;
public interface IDriverService
{
    Task<IEnumerable<Driver>> ListAsync();
    
    Task<DriverResponse> GetByIdAsync(int id);

    Task<DriverResponse> SaveAsync(Driver Driver);
    Task<DriverResponse> UpdateAsync(int id, Driver Driver);
    Task<DriverResponse> DeleteAsync(int id);
}
