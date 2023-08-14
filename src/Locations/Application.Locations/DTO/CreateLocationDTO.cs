using Application.Common.DTO;

namespace Application.Locations.DTO;

public record CreateLocationDTO : CreateDTO
{
    public required string Name { get; set; }
    public required string LevelFilepath { get; set; }
    public required string PosterFilepath { get; set; }
}
