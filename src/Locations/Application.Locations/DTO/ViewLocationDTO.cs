using Application.Common.DTO;

namespace Application.Locations.DTO;

public record ViewLocationDTO : ViewDTO
{
    public required string Name { get; set; }
    // public byte[] Poster { get; set; }
}
