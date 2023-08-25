using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record ViewUserInSessionDTO : ResponseDTO
{
    public Guid UserId { get; set; }
    public string Name { get; set; }

    public int KillCount { get; set; }
    public int DeathCount { get; set; }
}
