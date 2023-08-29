using Application.Common.DTO;

namespace Application.PlayerProfiles.DTO;

public record CreatePlayerProfileDTO : RequestDTO
{
    public required string Name { get; set; }
    public required Guid UserId { get; set; }
}
