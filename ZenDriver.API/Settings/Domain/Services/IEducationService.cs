using ZenDriver.API.Settings.Domain.Models;
using ZenDriver.API.Settings.Domain.Services.Communication;

namespace ZenDriver.API.Settings.Domain.Services;
public interface IEducationService
{
    Task<IEnumerable<Education>> ListAsync();
    
    Task<EducationResponse> SaveAsync(Education Education);
    Task<EducationResponse> UpdateAsync(int userId, Education Education);
    Task<EducationResponse> DeleteAsync(int userId);
    Task<Education> GetByDriverprofileidAsync(int driverprofileid);
}
