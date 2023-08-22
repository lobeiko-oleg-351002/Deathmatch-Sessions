using Application.Common.Interface;
using Application.Locations.DTO;

namespace Application.Locations.Interfaces;

public interface ILocationService : IService<ViewLocationDTO, CreateLocationDTO>
{
    Task<ViewLocationDTO> GetByName(string name);
}
