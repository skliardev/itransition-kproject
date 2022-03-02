using System.ComponentModel.DataAnnotations;

namespace project.Models;

public class SignUpModel
{
    [Display(Name = "User name")]
    [Required]
    public string UserName { get; set; } = null!;

    [Display(Name = "Email address")]
    [UIHint("Email")]
    [Required]
    public string UserEmail { get; set; } = null!;

    [Display(Name = "Password")]
    [UIHint("Password")]
    [Required]
    public string UserPassword { get; set; } = null!;
}

public class SignInModel
{
    [Display(Name = "Email address")]
    [UIHint("Email")]
    [Required]
    public string UserEmail { get; set; } = null!;

    [Display(Name = "Password")]
    [UIHint("Password")]
    [Required]
    public string UserPassword { get; set; } = null!;

    [Display(Name = "Remember me")]
    [Required]
    public bool RememberMe { get; set; } = false;
}