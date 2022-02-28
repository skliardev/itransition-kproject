using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using project.Domain.Entities;

namespace project.Controllers;

public class AdminController : Controller
{
    private UserManager<UserAccount> userManager;

    public AdminController(UserManager<UserAccount> userManager)
    {
        this.userManager = userManager;
    }
}