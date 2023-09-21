using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.ApplyForJob.Domain.Services.Communication;

namespace ZenDriver.API.ApplyForJob.Domain.Services;

public interface ICompanyService
{
    Task<IEnumerable<Company>> ListAsync();
    Task<Company> FindByIdAsync(int id);
    Task<CompanyResponse> SaveAsync(Company company);
    Task<CompanyResponse> UpdateAsync(int id, Company company);
    Task<CompanyResponse> DeleteAsync(int id);
}