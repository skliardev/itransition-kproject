
using System.ComponentModel.DataAnnotations;

namespace project.Models;

public class ListUsersModel
{
    [Required]
    [Display(Name = "User name")]
    public string UserName { get; set; }
}