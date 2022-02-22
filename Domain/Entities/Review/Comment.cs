
using System.ComponentModel.DataAnnotations;

namespace project.Domain.Entities.Review;

public class Comment
{
/* section references */
    [Required]
    [Display(Name = "Whose a comment")]
    public Guid AccountId { get; set; }

    [Required]
    [Display(Name = "Link by review")]
    public Guid ReviewId { get; set; }

/* section properties */
    [Display(Name = "Comment context")]
    public string Content { get; set; } = null!;

/* section collections */
}