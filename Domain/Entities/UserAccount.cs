using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace project.Domain.Entities;

public class UserAccount : IdentityUser
{
/* section references */
/* section properties */
    [Display(Name = "User status")]
    public UserStatus Status { get; set; } = UserStatus.OFFLINE;

    [Display(Name = "Last login")]
    public DateTime LastLogin { get; set; }

    [Display(Name = "Like count")]
    public int LikeCount { get; set; } = default;

/* section collections */
    [Display(Name = "My Reviews")]
    public ICollection<UserReview>? Reviews { get; set; }
}

public enum UserStatus 
{
    ONLINE,
    OFFLINE,
    LOCKED
}