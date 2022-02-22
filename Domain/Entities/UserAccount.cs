using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace project.Domain.Entities;

class UserAccount : IdentityUser
{
/* section references */
/* section properties */

/* section collections */
    [Display(Name = "My Reviews")]
    public ICollection<UserReview>? Reviews { get; set; }
}