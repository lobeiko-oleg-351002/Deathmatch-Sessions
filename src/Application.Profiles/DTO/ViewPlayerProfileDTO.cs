using Application.Common.DTO;

namespace Application.Profiles.DTO;

public record ViewPlayerProfileDTO : ResponseDTO
{
    public required string Name { get; set; }
}
