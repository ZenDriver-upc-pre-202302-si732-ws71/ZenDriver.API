using AutoMapper;
using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.ApplyForJob.Domain.Services;
using ZenDriver.API.ApplyForJob.Resources;
using ZenDriver.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ZenDriver.API.ApplyForJob.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RecruiterController : ControllerBase
{
    private readonly IRecruiterService _recruiterService;
    private readonly IMapper _mapper;
    
    public RecruiterController(IRecruiterService recruiterService, IMapper mapper)
    {
        _recruiterService = recruiterService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<RecruiterResource>> GetAllAsync()
    {
        var recruiters = await _recruiterService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Recruiter>, IEnumerable<RecruiterResource>>(recruiters);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRecruiterResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var recruiter = _mapper.Map<SaveRecruiterResource, Recruiter>(resource);
        var result = await _recruiterService.SaveAsync(recruiter);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var recruiterResource = _mapper.Map<Recruiter, RecruiterResource>(result.Resource);
        return Ok(recruiterResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRecruiterResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var recruiter = _mapper.Map<SaveRecruiterResource, Recruiter>(resource);
        var result = await _recruiterService.UpdateAsync(id, recruiter);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var recruiterResource = _mapper.Map<Recruiter, RecruiterResource>(result.Resource);
        return Ok(recruiterResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _recruiterService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var recruiterResource = _mapper.Map<Recruiter, RecruiterResource>(result.Resource);
        return Ok(recruiterResource);
    }
}