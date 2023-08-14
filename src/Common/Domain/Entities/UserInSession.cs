using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class UserInSession : BaseEntity
{
    [Required]
    public virtual User User { get; set; }

    [Required]
    public virtual required Session Session { get; set; }

    public int KillCount { get; set; }
    public int DeathCount { get; set; }


}
