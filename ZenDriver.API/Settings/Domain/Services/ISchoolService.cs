using ZenDriver.API.Settings.Domain.Models;
using ZenDriver.API.Settings.Domain.Services.Communication;

namespace ZenDriver.API.Settings.Domain.Services;
public interface ISchoolService
{
    Task<IEnumerable<School>> ListAsync();
    
    Task<SchoolResponse> SaveAsync(School School);
    Task<SchoolResponse> UpdateAsync(int userId, School School);
    Task<SchoolResponse> DeleteAsync(int userId);
    Task<School> GetByEducationidAsync(int educationid);
}
