
using System.ComponentModel.DataAnnotations;

namespace project.Models;

public class ListUsersModel
{
    [Required]
    [Display(Name = "User name")]
    public string UserName { get; set; } = null!;

    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Created")]
    public string Published { get; set; } = null!;

    [Display(Name = "Last login")]
    public string LastLogin { get; set; } = null!;

    [Display(Name = "Status")]
    public string Status { get; set; } = null!;
}