using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.DriverProfile.Domain.Services.Communication;

namespace ZenDriver.API.DriverProfile.Domain.Services;
public interface IDriverprofileService
{
    Task<IEnumerable<Models.DriverProfile>> ListAsync();
    
    Task<DriverprofileResponse> GetByIdAsync(int userId);
    Task<DriverprofileResponse> SaveAsync(Models.DriverProfile driverProfile);
    Task<DriverprofileResponse> UpdateAsync(int userId, Models.DriverProfile driverProfile);
    Task<DriverprofileResponse> DeleteAsync(int userId);
}
