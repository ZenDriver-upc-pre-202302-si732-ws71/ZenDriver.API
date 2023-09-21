using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.ApplyForJob.Domain.Services.Communication;

namespace ZenDriver.API.ApplyForJob.Domain.Services;

public interface IRecruiterService
{
    Task<IEnumerable<Recruiter>> ListAsync();
    Task<RecruiterResponse> SaveAsync(Recruiter recruiter);
    Task<RecruiterResponse> UpdateAsync(int id, Recruiter recruiter);
    Task<RecruiterResponse> DeleteAsync(int id);
}