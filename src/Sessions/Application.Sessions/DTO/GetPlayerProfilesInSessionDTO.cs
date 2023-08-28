using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record GetPlayerProfilesInSessionDTO : RequestDTO
{
    public required Guid SessionId { get; set; }
}
