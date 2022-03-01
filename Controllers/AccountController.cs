using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using project.Domain.Entities;
using project.Models;

namespace project.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly UserManager<UserAccount> userManager;
    private readonly SignInManager<UserAccount> signManager;

    public AccountController(UserManager<UserAccount> userManager, SignInManager<UserAccount> signManager)
    {
        this.userManager = userManager;
        this.signManager = signManager;
    }

    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ViewResult SignIn() => View();

    [AllowAnonymous]
    public ViewResult SignUp() => View();

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> SignUpAsync(SignUpModel model)
    {
        if(ModelState.IsValid)
        {
            UserAccount user = await userManager.FindByEmailAsync(model.UserEmail);
            if(user == default)
            {
                user = new UserAccount
                {
                    UserName = model.UserName,
                    NormalizedUserName = model.UserName.ToUpper(),
                    Email = model.UserEmail,
                    NormalizedEmail = model.UserEmail.ToUpper()
                };
                var result = await userManager.CreateAsync(user, model.UserPassword);
                if(result.Succeeded)
                {
                    return RedirectToAction(nameof(SignIn), new { returnUrl = "/"});
                }
                ModelState.AddModelError("", "Error create");
            }
            else
            {
                ModelState.AddModelError("", "User is exists");
            }
        }
        else
        {
            ModelState.AddModelError("", "User name or email or password error");
        }
        return View();
    }
}