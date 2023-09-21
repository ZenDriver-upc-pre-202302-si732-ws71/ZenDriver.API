using ZenDriver.API.Settings.Domain.Models;

namespace ZenDriver.API.Settings.Domain.Repositories;
public interface ISchoolRepository
{
    Task<IEnumerable<School>> ListAsync();
    Task AddAsync(School school);
    Task<School> FindByIdAsync(int id);
    void Update(School school);
    void Remove(School school);
    Task<School> FindByEducationIdAsync(int EducationId);
}
