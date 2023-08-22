using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record ViewUserInSessionDTO : ResponseDTO
{
    public required Guid UserId { get; set; }

    public int KillCount { get; set; }
    public int DeathCount { get; set; }
}
