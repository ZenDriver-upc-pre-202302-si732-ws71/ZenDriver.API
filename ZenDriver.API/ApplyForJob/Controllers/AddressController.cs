﻿using AutoMapper;
using ZenDriver.API.ApplyForJob.Domain.Models;
using ZenDriver.API.ApplyForJob.Domain.Services;
using ZenDriver.API.ApplyForJob.Resources;
using ZenDriver.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ZenDriver.API.ApplyForJob.Controllers;

[Route("/api/v1/[controller]")]

public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;
    private readonly IMapper _mapper;

    public AddressController(IAddressService addressService, IMapper mapper)
    {
        _addressService = addressService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<AddressResource>> GetAllAsync()
    {
        var address = await _addressService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Address>, IEnumerable<AddressResource>>(address);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAddressResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var address = _mapper.Map<SaveAddressResource, Address>(resource);

        var result = await _addressService.SaveAsync(address);

        if(!result.Success)
            return BadRequest(result.Message);

        var addressResource = _mapper.Map<Address, AddressResource>(result.Resource);

        return Ok(addressResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAddressResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var address = _mapper.Map<SaveAddressResource, Address>(resource);

        var result = await _addressService.UpdateAsync(id, address);

        if (!result.Success)
            return BadRequest(result.Message);

        var addressResource = _mapper.Map<Address, AddressResource>(result.Resource);

        return Ok(addressResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _addressService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var addressResource = _mapper.Map<Address, AddressResource>(result.Resource);
        return Ok(addressResource);
    }
}
