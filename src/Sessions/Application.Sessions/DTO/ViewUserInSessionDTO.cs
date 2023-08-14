using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record ViewUserInSessionDTO : ViewDTO
{
    public required string UserId { get; set; }

    public required string SessionId { get; set; }

    public int KillCount { get; set; }
    public int DeathCount { get; set; }
}
