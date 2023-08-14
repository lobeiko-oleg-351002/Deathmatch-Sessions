using Microsoft.EntityFrameworkCore;
using Infrastructure.Common.Repository;
using Domain.Interfaces;
using Infrastructure.Common;
using Infrastructure.Common.Logging;
using Domain.Entities;

namespace DAL.Repositories
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository(ApplicationDbContext context, ILogMessageManager<Session> logMessageManager) : base(context, logMessageManager)
        {

        }

        public async Task<int> GetCurrentPlayerCountInSession(Guid sessionId)
        {
            return await _context.UserInSessions.CountAsync(userInSession => userInSession.Session.Id == sessionId); 
        }
    }
}
