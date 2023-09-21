using AutoMapper;
using ZenDriver.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using ZenDriver.API.SocialNetworking.Domain.Models;
using ZenDriver.API.SocialNetworking.Domain.Services;
using ZenDriver.API.SocialNetworking.Resources;

namespace ZenDriver.API.SocialNetworking.Controllers;

[ApiController]
[Route("/api/v1/[Controller]")]
public class SocialNetworkController : ControllerBase
{
    private readonly ISocialNetworkService _socialNetworkService;
    private readonly IMapper _mapper;

    public SocialNetworkController(ISocialNetworkService socialNetworkService, IMapper mapper)
    {
        _socialNetworkService = socialNetworkService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SocialNetworkResource>> GetAllAsync()
    {
        var socialNetworks = await _socialNetworkService.ListAsync();
        var resources = _mapper.Map<IEnumerable<SocialNetwork>, IEnumerable<SocialNetworkResource>>(socialNetworks);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveSocialNetworkResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var socialNetwork = _mapper.Map<SaveSocialNetworkResource, SocialNetwork>(resource);

        var result = await _socialNetworkService.SaveAsync(socialNetwork);

        if (!result.Success)
            return BadRequest(result.Message);

        var socialNetworkResource = _mapper.Map<SocialNetwork, SocialNetworkResource>(result.Resource);

        return Ok(socialNetwork);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSocialNetworkResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var socialNetwork = _mapper.Map<SaveSocialNetworkResource, SocialNetwork>(resource);

        var result = await _socialNetworkService.UpdateAsync(id, socialNetwork);

        if (!result.Success)
            return BadRequest(result.Message);

        var socialNetworkResource = _mapper.Map<SocialNetwork, SocialNetworkResource>(result.Resource);

        return Ok(socialNetworkResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _socialNetworkService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var socialNetworkResource = _mapper.Map<SocialNetwork, SocialNetworkResource>(result.Resource);
        return Ok(socialNetworkResource);
    }
}
