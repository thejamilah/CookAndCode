using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cookware.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cookware.Pages.Member
{
    public class UserManageModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public UserManageModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public Cookware.Models.AccountViewModel.UpdateViewModel UpdateUser { get; set; }

        public void OnGet()
        {

        }

        /// <summary>
        /// Updates the product information
        /// </summary>
        /// <returns>Index page displaying all products</returns>
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Page();
            }

            ApplicationUser user = await _userManager.GetUserAsync(User);

            user.UserName = UpdateUser.Email;
            user.Email = UpdateUser.Email;
            user.FirstName = UpdateUser.FirstName;
            user.LastName = UpdateUser.LastName;

            Claim fullNameClaim = new Claim("FullName", $"{UpdateUser.FirstName} {UpdateUser.LastName}");

            // Reset password of user
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, resetToken, UpdateUser.Password);
            var updatedResult = await _userManager.UpdateAsync(user);

            return RedirectToPage("./MemberProfile");
        }
    }
}