using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Infrastructure.Common.Logging;
using Domain.Entities;

namespace Infrastructure.Common.Repository;

public class SessionRepository : Repository<Session>, ISessionRepository
{
    public SessionRepository(ApplicationDbContext context, ILogMessageManager<Session> logMessageManager) : base(context, logMessageManager)
    {

    }

    public async Task<int> GetCurrentPlayerCountInSession(Guid sessionId)
    {
        return await _context.ProfilesInSession.CountAsync(userInSession => userInSession.Session.Id == sessionId); 
    }
}
