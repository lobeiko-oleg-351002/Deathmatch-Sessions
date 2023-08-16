using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Common.Exceptions;
using Infrastructure.Common.Logging;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Repository;

public class UserInSessionRepository : Repository<UserInSession>, IUserInSessionRepository
{
    public UserInSessionRepository(ApplicationDbContext context, ILogMessageManager<UserInSession> logMessageManager) : base(context, logMessageManager)
    {

    }

    public async Task<List<UserInSession>> GetUsersInParticularSession(Session session)
    {
        var items = _context.UsersInSession.Where(item => item.Session.Id == session.Id);
        if (items.Any()) 
        {
            return await items.ToListAsync();
        }
        throw new NoElementsException();      
    }

    public async Task RemoveByUserId(Guid userId)
    {
        var itemToDelete = await _context.UsersInSession.FirstOrDefaultAsync(item => item.UserId == userId);
        if (itemToDelete != null)
        {
            _context.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
