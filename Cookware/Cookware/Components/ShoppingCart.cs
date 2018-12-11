using Cookware.Data;
using Cookware.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookware.Components
{
    public class ShoppingCart : ViewComponent
    {
        private CookwareDBContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ShoppingCart(CookwareDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Grabs all basket items related to user for shopping cart
        /// </summary>
        /// <returns>shopping cart</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var ID = user.Id;
                var shoppingCart = await _context.BasketItems.Where(x => x.UserID == ID && x.OrderID == 1).ToListAsync();
                return View(shoppingCart);
            }
            else
            {
                List<BasketItem> shoppingCart = new List<BasketItem>();
                return View(shoppingCart);
            }
        }
    }
}
