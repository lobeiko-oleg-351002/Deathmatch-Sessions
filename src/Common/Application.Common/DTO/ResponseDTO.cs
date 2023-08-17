namespace Application.Common.DTO;

public abstract record ResponseDTO
{
    public required string Id { get; set; }
}