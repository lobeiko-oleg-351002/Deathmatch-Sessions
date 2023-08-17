using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record GetUsersInSessionDTO : RequestDTO
{
    public required string SessionId { get; set; }
}
