using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Session : BaseEntity
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public int MaxPlayerCount { get; set; }

    [Required]
    public virtual required Location Level { get; set; }

    [Required]
    public required Guid UserHostId { get; set; }

    public virtual List<PlayerProfileInSession> UsersInSession { get; set; }
}
