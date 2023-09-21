using ZenDriver.API.DriverProfile.Domain.Repositories;
using ZenDriver.API.DriverProfile.Domain.Repositories;
using ZenDriver.API.Shared.Persistence.Contexts;
using ZenDriver.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ZenDriver.API.DriverProfile.Domain.Models.Persistence.Repositories;
public class DriverRepository : BaseRepository, IDriverRepository
{
    public DriverRepository(AppDbContext context) : base(context)
    {

    }
    
    public async Task<IEnumerable<Driver>> ListAsync()
    {
        return await _context.Drivers
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task AddAsync(Driver driver)
    {
        await _context.Drivers.AddAsync(driver);
    }

    public async Task<Driver> FindByIdAsync(int DriverId)
    {
        return await _context.Drivers
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == DriverId);
    }
    
    public void Update(Driver Driver)
    {
        _context.Drivers.Update(Driver);
    }

    public void Remove(Driver Driver)
    {
        _context.Drivers.Remove(Driver);
    }
}
