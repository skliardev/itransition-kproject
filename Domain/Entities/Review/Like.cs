
using System.ComponentModel.DataAnnotations;

namespace project.Domain.Entities.Review;

public class Like : EntityBase
{
/* section references */
    [Required]
    [Display(Name = "Whose a like")]
    public Guid AccountId { get; set; }

    [Required]
    [Display(Name = "Link by review")]
    public Guid ReviewId { get; set; }

/* section properties */
    [Display(Name = "Like state")]
    public bool IsLiked { get; set; }

/* section collections */
}