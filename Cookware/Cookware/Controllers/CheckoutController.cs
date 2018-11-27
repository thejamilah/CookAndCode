using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Data;
using Cookware.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Cookware.Controllers
{
    public class CheckoutController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private CookwareDBContext _context;

        public CheckoutController(UserManager<ApplicationUser> userManager, CookwareDBContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        
        public async Task<IActionResult> Receipt()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var ID = user.Id;
            var shoppingCart = await _context.BasketItems.Where(x => x.UserID == ID).Include(product => product.Product).ToListAsync();

            return View(shoppingCart);
        }
    }
}