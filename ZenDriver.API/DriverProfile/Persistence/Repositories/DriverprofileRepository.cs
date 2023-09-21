using ZenDriver.API.DriverProfile.Domain.Repositories;
using ZenDriver.API.Shared.Persistence.Contexts;
using ZenDriver.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using ZenDriver.API.DriverProfile.Domain.Models;

namespace ZenDriver.API.DriverProfile.Persistence.Repositories;
public class DriverprofileRepository : BaseRepository, IDriverprofileRepository
{
    public DriverprofileRepository(AppDbContext context) : base(context)
    {

    }
    
    public async Task<IEnumerable<Domain.Models.DriverProfile>> ListAsync()
    {
        return await _context.Driverprofiles
            .Include(p => p.Driver)
            .Include(p => p.License)
            .Include(p => p.Driver.User)
            .ToListAsync();
    }

    public async Task AddAsync(Domain.Models.DriverProfile driverProfile)
    {
        await _context.Driverprofiles.AddAsync(driverProfile);
    }

    public async Task<Domain.Models.DriverProfile> FindByIdAsync(int DriverprofileId)
    {
        return await _context.Driverprofiles
            .Include(p => p.Driver)
            .Include(p => p.License)
            .FirstOrDefaultAsync(p => p.Id == DriverprofileId);
    }
    
    public void Update(Domain.Models.DriverProfile driverProfile)
    {
        _context.Driverprofiles.Update(driverProfile);
    }

    public void Remove(Domain.Models.DriverProfile driverProfile)
    {
        _context.Driverprofiles.Remove(driverProfile);
    }
}
