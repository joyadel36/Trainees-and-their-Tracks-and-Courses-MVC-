using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using task1.ViewModels;
namespace task1.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> UManager { get; }
        private SignInManager<IdentityUser> SIManager { get; }
        public AccountController(UserManager<IdentityUser> umanager, SignInManager<IdentityUser> simanager)
        {
            UManager = umanager;
            SIManager = simanager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(SignUpAuthViewModel SUUser)
        {
            IdentityUser user = new IdentityUser();
            user.UserName = SUUser.UserName;
            user.PhoneNumber = SUUser.PhoneNumber;
            user.Email = SUUser.Email;
            user.PasswordHash = SUUser.Password;
            IdentityResult IResult = await UManager.CreateAsync(user, SUUser.Password);
            if (IResult.Succeeded)
            {

                await SIManager.SignInAsync(user, false);
  
                return RedirectToAction("Index", "Trainee");
            }
            else
            {
                foreach (var error in IResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LogInAuthViewModel LIUser,string returnUrl)
        {
            IdentityUser user = await UManager.FindByNameAsync(LIUser.UserName);
            if (user != null)
            {
                bool found = await UManager.CheckPasswordAsync(user, LIUser.Password);
                if (found)
                {
                    await SIManager.SignInAsync(user, LIUser.RememberMe);

                    if (!string.IsNullOrEmpty(returnUrl))
                    {

                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Trainee");
                    }

                }

            }

            ModelState.AddModelError("", "Wrong UserName Or Password");
            return View();
        }


        public IActionResult Logout()
        {

            SIManager.SignOutAsync();
            return RedirectToAction("Register", "Account");
        }
    }
}
