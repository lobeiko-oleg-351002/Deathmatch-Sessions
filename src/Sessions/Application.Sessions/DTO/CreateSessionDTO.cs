using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record CreateSessionDTO : RequestDTO
{
    public required string Name { get; set; }

    public required int MaxPlayerCount { get; set; }

    public required Guid LevelId { get; set; }

    public required Guid UserHostId { get; set; }
}
