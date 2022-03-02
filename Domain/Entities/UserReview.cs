using System.ComponentModel.DataAnnotations;
using project.Domain.Entities.Review;

namespace project.Domain.Entities;

public class UserReview : EntityBase
{
/* section references */
    [Required]
    [Display(Name = "Whose a review")]
    public Guid AccountId { get; set; }

    [Required]
    [Display(Name = "A group of review")]
    public Guid GroupId { get; set; }

    [Required]
    [Display(Name = "Title Image path")]
    public Guid TitleImageId { get; set; }

/* section properties */
    [Display(Name = "Title page")]
    public string Title { get; set; } = null!;

    [Display(Name = "Short text")]
    public string SubTitle { get; set; } = null!;

    [Display(Name = "Full text")]
    public string Text { get; set; } = null!;

    [Display(Name = "SEO metateg Title")]
    public string MetaTitle { get; set; } = null!;

    [Display(Name = "SEO metateg Description")]
    public string MetaDescription { get; set; } = null!;

    [Display(Name = "SEO metateg Keywords")]
    public string MetaKeywords { get; set; } = null!;

    [Display(Name = "Grade of Author"), Range(0, 6)]
    public byte GradeAuthor { get; set; } = default;

    [Display(Name = "Grades of Users"), Range(0, 6)]
    public byte GradesUsers { get; set; } = default;

    /* This service propety for recalc GradesUsers */
    public int GradesUsersCount { get; set; } = default;

/* section collections */
    [Display(Name = "Collection links of images")]
    public ICollection<Image>? ImagesLinks { get; set; }

    [Display(Name = "#Tags enter")]
    public ICollection<HashTag>? HashTags { get; set; }

    [Display(Name = "User likes")]
    public ICollection<Like>? Likes { get; set; }

    [Display(Name = "Comments")]
    public ICollection<Comment>? Comments { get; set; }
 }