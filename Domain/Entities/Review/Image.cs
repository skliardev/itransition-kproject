using System.ComponentModel.DataAnnotations;

namespace project.Domain.Entities.Review;

public class Image : EntityBase
{
/* section references */
    [Required]
    [Display(Name = "Link by review")]
    public Guid ReviewId { get; set; }
    
/* section properties */
    [Display(Name = "Image name")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Image url")]
    public string Url { get; set; } = string.Empty;

/* section collections */
}