using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.DriverProfile.Domain.Repositories;
using ZenDriver.API.DriverProfile.Domain.Services;
using ZenDriver.API.DriverProfile.Domain.Services.Communication;
using ZenDriver.API.Shared.Domain.Repositories;

namespace ZenDriver.API.DriverProfile.Services;
public class DriverprofileService : IDriverprofileService
{
    private readonly IDriverprofileRepository _DriverprofileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DriverprofileService(IDriverprofileRepository DriverprofileRepository, IUnitOfWork unitOfWork)
    {
        _DriverprofileRepository = DriverprofileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Models.DriverProfile>> ListAsync()
    {
        return await _DriverprofileRepository.ListAsync();
    }

    public async Task<DriverprofileResponse> SaveAsync(Domain.Models.DriverProfile driverProfile)
    {
        try
        {
            await _DriverprofileRepository.AddAsync(driverProfile);
            await _unitOfWork.CompleteAsync();
            return new DriverprofileResponse(driverProfile);
        }
        catch (Exception e)
        {
            return new DriverprofileResponse($"An error ocurred while saving the social Network: {e.Message}");
        }
    }

     public async Task<DriverprofileResponse> UpdateAsync(int id, Domain.Models.DriverProfile driverProfile)
     {
         var existingDriverprofile = await _DriverprofileRepository.FindByIdAsync(id);
    
         if (existingDriverprofile == null)
             return new DriverprofileResponse("Social Network not found");
         existingDriverprofile.DriverId = driverProfile.DriverId;
         existingDriverprofile.LicenseId = driverProfile.LicenseId;
         
         try
         {
             _DriverprofileRepository.Update(existingDriverprofile);
             await _unitOfWork.CompleteAsync();
    
             return new DriverprofileResponse(existingDriverprofile);
         }
         catch (Exception e)
         {
             return new DriverprofileResponse($"An error ocurred while updating the Social network: {e.Message}");
         }
     }

     public async Task<DriverprofileResponse> DeleteAsync(int id)
     {
        var existingDriverprofile = await _DriverprofileRepository.FindByIdAsync(id);
    
        if(existingDriverprofile == null)
            return new DriverprofileResponse("Social network not found");
        try
        {
            _DriverprofileRepository.Remove(existingDriverprofile);
            await _unitOfWork.CompleteAsync();
            return new DriverprofileResponse(existingDriverprofile);
        }
        catch (Exception e)
        {
            return new DriverprofileResponse($"An error ocurred while deleting the social network: {e.Message}");
        }
    }
     public async Task<DriverprofileResponse> GetByIdAsync(int id)
     {
         var driverprofile = await _DriverprofileRepository.FindByIdAsync(id);
         return new DriverprofileResponse(driverprofile);
     }
}