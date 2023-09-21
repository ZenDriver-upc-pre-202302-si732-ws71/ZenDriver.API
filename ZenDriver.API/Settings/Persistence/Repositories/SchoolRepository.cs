using ZenDriver.API.Shared.Persistence.Contexts;
using ZenDriver.API.Shared.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using ZenDriver.API.Settings.Domain.Models;
using ZenDriver.API.Settings.Domain.Repositories;

namespace ZenDriver.API.Settings.Persistence.Repositories;
public class SchoolRepository : BaseRepository, ISchoolRepository
{
    public SchoolRepository(AppDbContext context) : base(context)
    {

    }
    
    public async Task<IEnumerable<School>> ListAsync()
    {
        return await _context.Schools
            .Include(p => p.Education)
            .ToListAsync();
    }

    public async Task AddAsync(School School)
    {
        await _context.Schools.AddAsync(School);
    }

    public async Task<School> FindByIdAsync(int SchoolId)
    {
        return await _context.Schools
            .Include(p => p.Education)
            .FirstOrDefaultAsync(p => p.Id == SchoolId);
    }
    public async Task<School> FindByEducationIdAsync(int educationid)
    {
        return await _context.Schools.SingleOrDefaultAsync(x => x.EducationId == educationid);
    }
    
    public void Update(School School)
    {
        _context.Schools.Update(School);
    }

    public void Remove(School School)
    {
        _context.Schools.Remove(School);
    }
}
