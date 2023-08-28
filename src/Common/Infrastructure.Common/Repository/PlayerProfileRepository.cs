using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Common.Logging;

namespace Infrastructure.Common.Repository;

public class PlayerProfileRepository : Repository<PlayerProfile>, IPlayerProfileRepository
{
    public PlayerProfileRepository(ApplicationDbContext context, ILogMessageManager<PlayerProfile> logMessageManager) : base(context, logMessageManager)
    {

    }
}
