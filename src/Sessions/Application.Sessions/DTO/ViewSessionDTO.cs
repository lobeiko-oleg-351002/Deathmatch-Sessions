using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record ViewSessionDTO : ViewDTO
{
    public required string Name { get; set; }
    // public byte[] Poster { get; set; }
}
