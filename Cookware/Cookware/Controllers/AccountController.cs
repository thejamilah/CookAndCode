using Cookware.Models;
using Cookware.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace Cookware.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Registration page
        /// </summary>
        /// <returns>Display/direct to registration</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Creates user from registration parameters
        /// </summary>
        /// <param name="registervm">Register View Model parameters</param>
        /// <returns>Complted profile</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registervm)
        {
            if (ModelState.IsValid)
            {
                // start the registration process
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = registervm.Email,
                    Email = registervm.Email,
                    FirstName = registervm.FirstName,
                    LastName = registervm.LastName,
                    Birthday = registervm.Birthday,
                    Language = registervm.Language
                };

                var result = await _userManager.CreateAsync(user, registervm.Password);
                
                if (result.Succeeded)
                {
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim birthdayClaim = new Claim(
                        ClaimTypes.DateOfBirth,
                        new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);

                    Claim languageClaim = new Claim("FavoriteLanguage", "C#");

                    List<Claim> myclaims = new List<Claim>()
                    {
                        fullNameClaim,
                        emailClaim,
                        birthdayClaim,
                        languageClaim
                    };

                    await _userManager.AddClaimsAsync(user, myclaims);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(registervm);
        }

        /// <summary>
        /// Displays Login Page
        /// </summary>
        /// <returns>Login view</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Action that accepts user login
        /// </summary>
        /// <param name="lvm">User login credentials</param>
        /// <returns>Confirmed login or invalid username/password</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invlalid Username or Password.");
                }
            }
            return View(lvm);
        }

        /// <summary>
        /// Logout page
        /// </summary>
        /// <returns>Home page</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}
