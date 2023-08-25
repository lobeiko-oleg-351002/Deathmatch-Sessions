using Application.Common.DTO;

namespace Application.Sessions.DTO;

public record ViewUserDTO : ResponseDTO
{
    public required string Name { get; set;}
}
