using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using M12Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace M12Assignment.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<User> userMngr,
            SignInManager<User> signInMngr, RoleManager<IdentityRole> roleMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            roleManager = roleMngr;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { 
                    UserName = model.Username,
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent : false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors) 
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        //I followed this tutorial to get google's authentication working for a custom login page in asp.net core
        //https://www.yogihosting.com/aspnet-core-identity-login-with-google/
        [AllowAnonymous]
        public IActionResult GoogleLogin()
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse()
        {
            ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction("Login");

            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
            User loginInformation = new User() { Id = info.ProviderKey, UserName = info.Principal.FindFirst(ClaimTypes.Email).Value };
            if (await roleManager.FindByNameAsync("Administrator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }
            var addingRole = await userManager.AddToRoleAsync(loginInformation, "Administrator");
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
            {
                LoginViewModel user = new LoginViewModel
                {
                    Username = info.Principal.FindFirst(ClaimTypes.Email).Value
                };

                var signIn = await signInManager.PasswordSignInAsync(
                    user.Username, user.Password, isPersistent: user.RememberMe,
                    lockoutOnFailure: false);
                if (signIn.Succeeded)
                {
                    if (!string.IsNullOrEmpty(user.ReturnUrl) &&
                        Url.IsLocalUrl(user.ReturnUrl))
                    {
                        return Redirect(user.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                return AccessDenied();
            }
        }


        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnURL };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {                
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password, isPersistent: model.RememberMe, 
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && 
                        Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        public ViewResult AccessDenied()
        {
            return View();
        }
    }
}