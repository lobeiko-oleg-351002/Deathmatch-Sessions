using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserInSessionRepository : IRepository<UserInSession>
{
    Task RemoveByUserId(Guid userId);
    Task<List<UserInSession>> GetUsersInParticularSession(Session session);
}
