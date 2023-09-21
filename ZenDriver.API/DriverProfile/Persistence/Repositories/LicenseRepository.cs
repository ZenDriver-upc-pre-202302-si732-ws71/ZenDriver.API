using ZenDriver.API.DriverProfile.Domain.Models;
using ZenDriver.API.Shared.Persistence.Contexts;
using ZenDriver.API.Shared.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using ZenDriver.API.DriverProfile.Domain.Repositories;

namespace ZenDriver.API.DriverProfile.Persistence.Repositories;
public class LicenseRepository : BaseRepository, ILicenseRepository
{
    public LicenseRepository(AppDbContext context) : base(context)
    {

    }
    
    public async Task<IEnumerable<License>> ListAsync()
    {
        return await _context.Licenses
            .ToListAsync();
    }

    public async Task AddAsync(License License)
    {
        await _context.Licenses.AddAsync(License);
    }

    public async Task<License> FindByIdAsync(int LicenseId)
    {
        return await _context.Licenses
            .FirstOrDefaultAsync(p => p.Id == LicenseId);
    }
    
    public void Update(License License)
    {
        _context.Licenses.Update(License);
    }

    public void Remove(License License)
    {
        _context.Licenses.Remove(License);
    }
}
