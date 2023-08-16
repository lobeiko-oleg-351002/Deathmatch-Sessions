using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record GetUsersInSessionDTO : ViewDTO
{
    public required string SessionId { get; set; }
}
