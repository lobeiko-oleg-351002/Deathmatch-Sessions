using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Common.Exceptions;
using Infrastructure.Common.Logging;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Repository;

public class PlayerProfileInSessionRepository : Repository<PlayerProfileInSession>, IPlayerProfileInSessionRepository
{
    public PlayerProfileInSessionRepository(ApplicationDbContext context, ILogMessageManager<PlayerProfileInSession> logMessageManager) : base(context, logMessageManager)
    {

    }

    public async Task<List<PlayerProfileInSession>> GetProfilesInParticularSession(Session session)
    {
        var items = _context.ProfilesInSession.Where(item => item.Session.Id == session.Id);
        if (items.Any()) 
        {
            return await items.ToListAsync();
        }
        throw new NoElementsException();      
    }

    public async Task RemoveByProfileId(Guid id)
    {
        var itemToDelete = await _context.ProfilesInSession.FirstOrDefaultAsync(item => item.PlayerProfile.Id == id);
        if (itemToDelete != null)
        {
            _context.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
