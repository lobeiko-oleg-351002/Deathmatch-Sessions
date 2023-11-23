using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Infrastructure.Common.Logging;
using Domain.Entities;

namespace Infrastructure.Common.Repository;

public class SessionRepository : Repository<Session>, ISessionRepository
{
    private readonly ILoggerRepository _loggerRepository;
    public SessionRepository(ApplicationDbContext context, ILogMessageManager<Session> logMessageManager, ILoggerRepository loggerRepository) : base(context, logMessageManager)
    {
        _loggerRepository = loggerRepository;
    }

    public async Task<int> GetCurrentPlayerCountInSession(Guid sessionId)
    {
        return await _context.ProfilesInSession.CountAsync(userInSession => userInSession.Session.Id == sessionId); 
    }

    public override Task<Session> Create(Session entity)
    {
        _loggerRepository.AddLogRecord(new SessionLog { Name = entity.Name, DateCreated = DateTime.UtcNow, HostId = entity.UserHostId.ToString() });
        return base.Create(entity);
    }
}
