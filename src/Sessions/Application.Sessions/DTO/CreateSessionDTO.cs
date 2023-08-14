using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record CreateSessionDTO : CreateDTO
{
    public required string Name { get; set; }

    public required int MaxPlayerCount { get; set; }

    public required string LevelId { get; set; }

    public required string UserHostId { get; set; }
}
