using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Location : BaseEntity
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string PosterFilepath { get; set; }
    [Required]
    public required string LevelFilepath { get; set; }
}
