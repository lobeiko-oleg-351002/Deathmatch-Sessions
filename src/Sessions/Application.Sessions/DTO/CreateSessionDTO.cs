using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record CreateSessionDTO : CreateDTO
{
    public required string Name { get; set; }
    public required string LevelFilepath { get; set; }
    public required string PosterFilepath { get; set; }
}
