using ZenDriver.API.DriverProfile.Domain.Repositories;
using ZenDriver.API.DriverProfile.Domain.Services;
using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.DriverProfile.Domain.Repositories;
using ZenDriver.API.DriverProfile.Domain.Services;
using ZenDriver.API.DriverProfile.Domain.Services.Communication;
using ZenDriver.API.Shared.Domain.Repositories;

namespace ZenDriver.API.DriverProfile.Services;
public class DriverService : IDriverService
{
    private readonly IDriverRepository _DriverRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DriverService(IDriverRepository DriverRepository, IUnitOfWork unitOfWork)
    {
        _DriverRepository = DriverRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Driver>> ListAsync()
    {
        return await _DriverRepository.ListAsync();
    }

    public async Task<DriverResponse> GetByIdAsync(int id)
    {
        var driver = await _DriverRepository.FindByIdAsync(id);
        return new DriverResponse(driver);
    }

    public async Task<DriverResponse> SaveAsync(Driver Driver)
    {
        try
        {
            await _DriverRepository.AddAsync(Driver);
            await _unitOfWork.CompleteAsync();
            return new DriverResponse(Driver);
        }
        catch (Exception e)
        {
            return new DriverResponse($"An error ocurred while saving the Driver: {e.Message}");
        }
    }

    public async Task<DriverResponse> UpdateAsync(int id, Driver Driver)
    {
        var existingDriver = await _DriverRepository.FindByIdAsync(id);

        if (existingDriver == null)
            return new DriverResponse("Driver not found");
        existingDriver.UserId = Driver.UserId;

        try
        {
            _DriverRepository.Update(existingDriver);
            await _unitOfWork.CompleteAsync();

            return new DriverResponse(existingDriver);
        }
        catch (Exception e)
        {
            return new DriverResponse($"An error ocurred while updating the Driver: {e.Message}");
        }
    }

    public async Task<DriverResponse> DeleteAsync(int id)
    {
        var existingDriver = await _DriverRepository.FindByIdAsync(id);

        if(existingDriver == null)
            return new DriverResponse("Driver not found");
        try
        {
            _DriverRepository.Remove(existingDriver);
            await _unitOfWork.CompleteAsync();
            return new DriverResponse(existingDriver);
        }
        catch (Exception e)
        {
            return new DriverResponse($"An error ocurred while deleting the Driver: {e.Message}");
        }
    }
}