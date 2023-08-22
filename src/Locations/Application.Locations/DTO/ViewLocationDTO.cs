using Application.Common.DTO;

namespace Application.Locations.DTO;

public record ViewLocationDTO : ResponseDTO
{
    public required string Name { get; set; }
}
