using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Models;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cookware.Pages.Admin
{
    public class UserProfileModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IOrder _order;

        public UserProfileModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOrder order)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _order = order;
        }

        
        public IEnumerable<Cookware.Models.Order> Orders { get; set; }

        /// <summary>
        /// Gets top five user orders for displaying on page.
        /// </summary>
        public async Task<IActionResult> OnGet()
        {
            //Get user id
            var id = _userManager.GetUserId(User);

            //Get top 5 orders for user
            Orders = await _order.GetTopFiveOrders(id);

            return Page();
        }
    }
}