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
    public virtual User Host { get; set; }

    public virtual required List<UserInSession> UsersInSession { get; set; }
}
