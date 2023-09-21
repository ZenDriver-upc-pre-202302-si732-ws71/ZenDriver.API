using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.ApplyForJob.Domain.Repositories;
using ZenDriver.API.ApplyForJob.Domain.Services;
using ZenDriver.API.ApplyForJob.Domain.Services.Communication;
using ZenDriver.API.Shared.Domain.Repositories;

namespace ZenDriver.API.ApplyForJob.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
    {
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Company>> ListAsync()
    {
        return await _companyRepository.ListAsync();
    }

    public async Task<Company> FindByIdAsync(int id)
    {
        return await _companyRepository.FindByIdAsync(id);
    }

    public async Task<CompanyResponse> SaveAsync(Company company)
    {
        try
        {
            await _companyRepository.AddAsync(company);
            await _unitOfWork.CompleteAsync();
            return new CompanyResponse(company);
        }
        catch (Exception e)
        {
            return new CompanyResponse($"An error occurred when saving the company: {e.Message}");
        }
    }

    public async Task<CompanyResponse> UpdateAsync(int id, Company company)
    {
        var existingCompany = await _companyRepository.FindByIdAsync(id);
        
        if (existingCompany == null)
            return new CompanyResponse("Company not found.");
        existingCompany = company;

        try
        {
            _companyRepository.Update(existingCompany);
            await _unitOfWork.CompleteAsync();

            return new CompanyResponse(company);
        }
        catch (Exception e)
        {
            return new CompanyResponse(($"An error occurred when updating the company: {e.Message}"));
        }
    }

    public async Task<CompanyResponse> DeleteAsync(int id)
    {
        var existingCompany = await _companyRepository.FindByIdAsync(id);
        
        if (existingCompany == null)
            return new CompanyResponse("Company not found.");
        try
        {
            _companyRepository.Remove(existingCompany);
            await _unitOfWork.CompleteAsync();
            return new CompanyResponse(existingCompany);
        }
        catch (Exception e)
        {
            return new CompanyResponse(($"An error occurred when deleting the company: {e.Message}"));
        }
    }
}