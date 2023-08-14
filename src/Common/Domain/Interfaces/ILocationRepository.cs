using Domain.Entities;

namespace Domain.Interfaces;

public interface ILocationRepository : IRepository<Location>
{
    Task<Location> GetByName(string name);
}
