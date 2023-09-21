using ZenDriver.API.Shared.Domain.Repositories;
using ZenDriver.API.Settings.Domain.Models;
using ZenDriver.API.Settings.Domain.Repositories;
using ZenDriver.API.Settings.Domain.Services;
using ZenDriver.API.Settings.Domain.Services.Communication;

namespace ZenDriver.API.Settings.Services;
public class EducationService : IEducationService
{
    private readonly IEducationRepository _EducationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EducationService(IEducationRepository EducationRepository, IUnitOfWork unitOfWork)
    {
        _EducationRepository = EducationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Education>> ListAsync()
    {
        return await _EducationRepository.ListAsync();
    }

    public async Task<EducationResponse> SaveAsync(Education Education)
    {
        try
        {
            await _EducationRepository.AddAsync(Education);
            await _unitOfWork.CompleteAsync();
            return new EducationResponse(Education);
        }
        catch (Exception e)
        {
            return new EducationResponse($"An error ocurred while saving the social Network: {e.Message}");
        }
    }
    public async Task<Education> GetByDriverprofileidAsync(int driverprofileid)
    {
        var education = await _EducationRepository.FindByDriverprofileIdAsync(driverprofileid);
        //Validate
        if (education == null )
        {
            throw new KeyNotFoundException("Driver not found");
        }
        return education;
    }

    public async Task<EducationResponse> UpdateAsync(int id, Education Education)
    {
        var existingEducation = await _EducationRepository.FindByIdAsync(id);

        if (existingEducation == null)
            return new EducationResponse("Education not found");
        existingEducation.Grade_education = Education.Grade_education;
        existingEducation.DriverprofileId = Education.DriverprofileId;
        try
        {
            _EducationRepository.Update(existingEducation);
            await _unitOfWork.CompleteAsync();

            return new EducationResponse(existingEducation);
        }
        catch (Exception e)
        {
            return new EducationResponse($"An error ocurred while updating the Social network: {e.Message}");
        }
    }

    public async Task<EducationResponse> DeleteAsync(int id)
    {
        var existingEducation = await _EducationRepository.FindByIdAsync(id);

        if(existingEducation == null)
            return new EducationResponse("Social network not found");
        try
        {
            _EducationRepository.Remove(existingEducation);
            await _unitOfWork.CompleteAsync();
            return new EducationResponse(existingEducation);
        }
        catch (Exception e)
        {
            return new EducationResponse($"An error ocurred while deleting the social network: {e.Message}");
        }
    }
}