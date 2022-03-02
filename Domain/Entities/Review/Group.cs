
using System.ComponentModel.DataAnnotations;

namespace project.Domain.Entities.Review;

public class Group : EntityBase
{
/* section references */

/* section properties */
    [Required]
    [Display(Name = "Group name")]
    public string Name { get; set; } = null!;

/* section collections */
}