using Domain.Entities;

namespace Domain.Interfaces;

public interface IPlayerProfileInSessionRepository : IRepository<PlayerProfileInSession>
{
    Task RemoveByProfileId(Guid id);
    Task<List<PlayerProfileInSession>> GetProfilesInParticularSession(Session session);
}
