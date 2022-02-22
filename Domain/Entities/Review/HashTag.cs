
using System.ComponentModel.DataAnnotations;

namespace project.Domain.Entities.Review;

public class HashTag : EntityBase
{
/* section references */

/* section properties */
    [Required]
    [Display(Name = "Tag name")]
    public string Name { get; set; } = null!;

/* section collections */
}