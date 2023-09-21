using ZenDriver.API.Shared.Persistence.Contexts;
using ZenDriver.API.Shared.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using ZenDriver.API.Settings.Domain.Models;
using ZenDriver.API.Settings.Domain.Repositories;

namespace ZenDriver.API.Settings.Persistence.Repositories;
public class EducationRepository : BaseRepository, IEducationRepository
{
    public EducationRepository(AppDbContext context) : base(context)
    {

    }
    
    public async Task<IEnumerable<Education>> ListAsync()
    {
        return await _context.Educations
            .Include(p => p.DriverProfile)
            .ToListAsync();
    }

    public async Task AddAsync(Education Education)
    {
        await _context.Educations.AddAsync(Education);
    }

    public async Task<Education> FindByIdAsync(int EducationId)
    {
        return await _context.Educations
            .Include(p => p.DriverProfile)
            .FirstOrDefaultAsync(p => p.Id == EducationId);
    }
    public async Task<Education> FindByDriverprofileIdAsync(int driverprofileid)
    {
        return await _context.Educations.SingleOrDefaultAsync(x => x.DriverprofileId == driverprofileid);
    }
    public void Update(Education Education)
    {
        _context.Educations.Update(Education);
    }

    public void Remove(Education Education)
    {
        _context.Educations.Remove(Education);
    }
}
