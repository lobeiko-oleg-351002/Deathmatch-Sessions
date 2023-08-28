using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class PlayerProfileInSession : BaseEntity
{
    [Required]
    public virtual required PlayerProfile PlayerProfile { get; set; }
    [Required]
    public virtual required Session Session { get; set; }
    [Required]
    public required int KillCount { get; set; }
    [Required]
    public required int DeathCount { get; set; }
}
