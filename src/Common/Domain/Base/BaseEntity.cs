using System.ComponentModel.DataAnnotations;

namespace Domain;

public abstract class BaseEntity
{
    [Key, Required]
    public Guid Id { get; set; }
}
