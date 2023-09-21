using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.ApplyForJob.Domain.Repositories;
using ZenDriver.API.ApplyForJob.Domain.Services;
using ZenDriver.API.ApplyForJob.Domain.Services.Communication;
using ZenDriver.API.Security.Domain.Repositories;
using ZenDriver.API.Shared.Domain.Repositories;

namespace ZenDriver.API.ApplyForJob.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public AddressService(IAddressRepository addressRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Address>> ListAsync()
    {
        return await _addressRepository.ListAsync();
    }

    public async Task<IEnumerable<Address>> ListByUserIdAsync(int userId)
    {
        return await _addressRepository.FindByUserIdAsyn(userId);
    }

    public async Task<AddressResponse> SaveAsync(Address address)
    {
        var existingUser = await _userRepository.FindByIdAsync(address.UserId);

        if (existingUser == null)
            return new AddressResponse("Invalid User");

        try
        {
            //Add Address
            await _addressRepository.AddAsync(address);
            await _unitOfWork.CompleteAsync();

            //Return response
            return new AddressResponse(address);
        }
        catch (Exception e)
        {
            //Error Handling
            return new AddressResponse($"An error ocurred while saving the tutorial: {e.Message}");
        }
    }

    public async Task<AddressResponse> UpdateAsync(int addressId, Address address)
    {
        var existingAddress = await _addressRepository.FindByIdAsync(addressId);
        //Validate Address
        if(existingAddress == null)
        {
            return new AddressResponse("Invalid Address");
        }
        //Validate UserId
        var existingUser = await _userRepository.FindByIdAsync(address.UserId);
        if (existingUser == null)
            return new AddressResponse("Invalid User");

        //Modify Fields
        existingAddress.NameAddress = address.NameAddress;

        try
        {
            _addressRepository.Update(existingAddress);
            await _unitOfWork.CompleteAsync();
            return new AddressResponse(existingAddress);
        }
        catch (Exception e)
        {
            return new AddressResponse($"An error ocurred while updating the address: {e.Message}");
        }
    }

    public async Task<AddressResponse> DeleteAsync(int addressId)
    {
        var existingAddress = await _addressRepository.FindByIdAsync(addressId);
        //Validate Address
        if (existingAddress == null)
            return new AddressResponse("Address not found");
        try
        {
            _addressRepository.Remove(existingAddress);
            await _unitOfWork.CompleteAsync();
            return new AddressResponse(existingAddress);
        }
        catch (Exception e)
        {
            return new AddressResponse($"An error ocurred while deleting the address: {e.Message}");
        }
    }

}
