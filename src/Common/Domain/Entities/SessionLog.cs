using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class SessionLog
{
    public required string Name { get; set; }

    public DateTime DateCreated { get; set; }

    public required string HostId { get; set; }

}
