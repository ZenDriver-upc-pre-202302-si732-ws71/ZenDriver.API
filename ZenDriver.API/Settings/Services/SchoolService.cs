using ZenDriver.API.Shared.Domain.Repositories;
using ZenDriver.API.Settings.Domain.Models;
using ZenDriver.API.Settings.Domain.Repositories;
using ZenDriver.API.Settings.Domain.Services;
using ZenDriver.API.Settings.Domain.Services.Communication;

namespace ZenDriver.API.Settings.Services;
public class SchoolService : ISchoolService
{
    private readonly ISchoolRepository _SchoolRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SchoolService(ISchoolRepository SchoolRepository, IUnitOfWork unitOfWork)
    {
        _SchoolRepository = SchoolRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<School>> ListAsync()
    {
        return await _SchoolRepository.ListAsync();
    }

    public async Task<SchoolResponse> SaveAsync(School School)
    {
        try
        {
            await _SchoolRepository.AddAsync(School);
            await _unitOfWork.CompleteAsync();
            return new SchoolResponse(School);
        }
        catch (Exception e)
        {
            return new SchoolResponse($"An error ocurred while saving the social Network: {e.Message}");
        }
    }
    public async Task<School> GetByEducationidAsync(int educationid)
    {
        var school = await _SchoolRepository.FindByEducationIdAsync(educationid);
        //Validate
        if (school == null )
        {
            throw new KeyNotFoundException("Driver not found");
        }
        return school;
    }

    public async Task<SchoolResponse> UpdateAsync(int id, School School)
    {
        var existingSchool = await _SchoolRepository.FindByIdAsync(id);

        if (existingSchool == null)
            return new SchoolResponse("Social Network not found");
        existingSchool.name_school = School.name_school;
        existingSchool.type = School.type;
        existingSchool.EducationId = School.EducationId;
        
        try
        {
            _SchoolRepository.Update(existingSchool);
            await _unitOfWork.CompleteAsync();

            return new SchoolResponse(existingSchool);
        }
        catch (Exception e)
        {
            return new SchoolResponse($"An error ocurred while updating the Social network: {e.Message}");
        }
    }

    public async Task<SchoolResponse> DeleteAsync(int id)
    {
        var existingSchool = await _SchoolRepository.FindByIdAsync(id);

        if(existingSchool == null)
            return new SchoolResponse("Social network not found");
        try
        {
            _SchoolRepository.Remove(existingSchool);
            await _unitOfWork.CompleteAsync();
            return new SchoolResponse(existingSchool);
        }
        catch (Exception e)
        {
            return new SchoolResponse($"An error ocurred while deleting the social network: {e.Message}");
        }
    }
}