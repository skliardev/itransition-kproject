using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace project.Controllers;

[Authorize]
public class AccountController : Controller
{
    [AllowAnonymous]
    // [ValidateAntiForgeryToken]
    public ViewResult SignIn() => View();

    [AllowAnonymous]
    public ViewResult SignUp() => View();

}