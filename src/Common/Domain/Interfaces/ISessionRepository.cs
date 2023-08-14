using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISessionRepository : IRepository<Session>
    {
        Task<int> GetCurrentPlayerCountInSession(Guid sessionId);
    }
}
