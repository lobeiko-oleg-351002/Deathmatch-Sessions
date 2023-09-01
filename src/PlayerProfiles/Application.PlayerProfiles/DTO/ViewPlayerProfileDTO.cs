using Application.Common.DTO;

namespace Application.PlayerProfiles.DTO;

public record ViewPlayerProfileDTO : ResponseDTO
{
    public required string Name { get; set; }
}
