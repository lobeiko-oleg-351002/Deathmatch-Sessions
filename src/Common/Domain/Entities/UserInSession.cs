using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class UserInSession : BaseEntity
{
    [Required]
    public required Guid UserId { get; set; }
    [Required]
    public virtual required Session Session { get; set; }
    [Required]
    public required int KillCount { get; set; }
    [Required]
    public required int DeathCount { get; set; }
}
