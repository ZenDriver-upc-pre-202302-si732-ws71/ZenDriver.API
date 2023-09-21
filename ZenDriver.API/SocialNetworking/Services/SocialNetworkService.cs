using ZenDriver.API.Shared.Domain.Repositories;
using ZenDriver.API.SocialNetworking.Domain.Models;
using ZenDriver.API.SocialNetworking.Domain.Repositories;
using ZenDriver.API.SocialNetworking.Domain.Services;
using ZenDriver.API.SocialNetworking.Domain.Services.Communication;

namespace ZenDriver.API.SocialNetworking.Services;
public class SocialNetworkService : ISocialNetworkService
{
    private readonly ISocialNetworkRepository _socialNetworkRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SocialNetworkService(ISocialNetworkRepository socialNetworkRepository, IUnitOfWork unitOfWork)
    {
        _socialNetworkRepository = socialNetworkRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SocialNetwork>> ListAsync()
    {
        return await _socialNetworkRepository.ListAsync();
    }

    public async Task<SocialNetworkResponse> SaveAsync(SocialNetwork socialNetwork)
    {
        try
        {
            await _socialNetworkRepository.AddAsync(socialNetwork);
            await _unitOfWork.CompleteAsync();
            return new SocialNetworkResponse(socialNetwork);
        }
        catch (Exception e)
        {
            return new SocialNetworkResponse($"An error ocurred while saving the social Network: {e.Message}");
        }
    }

    public async Task<SocialNetworkResponse> UpdateAsync(int id, SocialNetwork socialNetwork)
    {
        var existingSocialNetwork = await _socialNetworkRepository.FindByIdAsync(id);

        if (existingSocialNetwork == null)
            return new SocialNetworkResponse("Social Network not found");
        existingSocialNetwork.DescriptionSocialNetwork = socialNetwork.DescriptionSocialNetwork;
        existingSocialNetwork.UrlImageSocialNetwork = socialNetwork.UrlImageSocialNetwork;
        existingSocialNetwork.Like = socialNetwork.Like;
        
        try
        {
            _socialNetworkRepository.Update(existingSocialNetwork);
            await _unitOfWork.CompleteAsync();

            return new SocialNetworkResponse(existingSocialNetwork);
        }
        catch (Exception e)
        {
            return new SocialNetworkResponse($"An error ocurred while updating the Social network: {e.Message}");
        }
    }

    public async Task<SocialNetworkResponse> DeleteAsync(int id)
    {
        var existingSocialNetwork = await _socialNetworkRepository.FindByIdAsync(id);

        if(existingSocialNetwork == null)
            return new SocialNetworkResponse("Social network not found");
        try
        {
            _socialNetworkRepository.Remove(existingSocialNetwork);
            await _unitOfWork.CompleteAsync();
            return new SocialNetworkResponse(existingSocialNetwork);
        }
        catch (Exception e)
        {
            return new SocialNetworkResponse($"An error ocurred while deleting the social network: {e.Message}");
        }
    }
}