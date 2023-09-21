using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.DriverProfile.Domain.Services.Communication;

namespace ZenDriver.API.DriverProfile.Domain.Services;
public interface ILicenseService
{
    Task<IEnumerable<License>> ListAsync();
    
    Task<LicenseResponse> SaveAsync(License License);
    Task<LicenseResponse> UpdateAsync(int userId, License License);
    Task<LicenseResponse> DeleteAsync(int userId);
}
