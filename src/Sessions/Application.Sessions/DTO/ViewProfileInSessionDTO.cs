using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record ViewProfileInSessionDTO : ResponseDTO
{
    public string Name { get; set; }

    public int KillCount { get; set; }
    public int DeathCount { get; set; }
}
