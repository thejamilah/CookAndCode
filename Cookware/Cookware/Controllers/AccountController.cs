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

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registervm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = registervm.Email,
                    Email = registervm.Email,
                    FirstName = registervm.FirstName,
                    LastName = registervm.LastName,
                    Birthday = registervm.Birthday
                };

                var result = await _userManager.CreateAsync(user, registervm.Password);
                if (result.Succeeded)
                {
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    List<Claim> myclaims = new List<Claim>()
                    {
                        fullNameClaim
                    };

                    await _userManager.AddClaimAsync(user, myclaims[0]);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(" ", item.Description);
                    }
                }
            }

            return View(registervm);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginvm)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginvm.Email, loginvm.Password, false, false);

                if(result.Succeeded)
                {
                    RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Are you sure you entered the right info?");
            }

        return View(loginvm);

        }

    }
}
