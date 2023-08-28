using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class PlayerProfile : BaseEntity
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required Guid UserId { get; set; }
}
