using System.ComponentModel.DataAnnotations;

namespace project.Domain.Entities;

public abstract class EntityBase
{
    protected EntityBase() => Published = DateTime.UtcNow;

    [Required]
    public Guid Id { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime Published { get; set; }
}