using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record ViewSessionDTO : ResponseDTO
{
    public required string Name { get; set; }
    public string HostName { get; set; }
}
