using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Common.Exceptions;
using Infrastructure.Common.Logging;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Repository;

public class LocationRepository : Repository<Location>, ILocationRepository
{
    public LocationRepository(ApplicationDbContext context, ILogMessageManager<Location> logMessageManager) : base(context, logMessageManager)
    {

    }

    public async Task<Location> GetByName(string name)
    {
        _logMessageManager.LogCustomMessage("GetByName.Name: " + name);
        var entity = await _context.Locations.FirstOrDefaultAsync(e => (e.Name == name));
        if (entity == null)
        {
            var ex = new ItemNotFoundException();
            _logMessageManager.LogFailure(ex.Message);
            throw ex;
        }
        _logMessageManager.LogSuccess();
        return entity;
    }
}
