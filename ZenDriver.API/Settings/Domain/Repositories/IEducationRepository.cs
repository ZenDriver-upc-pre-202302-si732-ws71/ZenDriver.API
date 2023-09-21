using ZenDriver.API.Settings.Domain.Models;

namespace ZenDriver.API.Settings.Domain.Repositories;
public interface IEducationRepository
{
    Task<IEnumerable<Education>> ListAsync();
    Task AddAsync(Education education);
    Task<Education> FindByIdAsync(int id);
    void Update(Education education);
    void Remove(Education education);
    Task<Education> FindByDriverprofileIdAsync(int DriverprofileId);
}
