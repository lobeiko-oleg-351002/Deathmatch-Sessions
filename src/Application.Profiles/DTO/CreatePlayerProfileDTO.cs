using Application.Common.DTO;

namespace Application.Profiles.DTO;

public record CreatePlayerProfileDTO : RequestDTO
{
    public required string Name { get; set; }
    public required Guid UserId { get; set; }
}
