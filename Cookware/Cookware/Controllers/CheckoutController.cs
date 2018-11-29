using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Data;
using Cookware.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private IEmailSender _email;

        public CheckoutController(UserManager<ApplicationUser> userManager, CookwareDBContext context, IEmailSender email)
        {
            _userManager = userManager;
            _context = context;
            _email = email;
        }
        
        public async Task<IActionResult> Receipt()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var ID = user.Id;
            var shoppingCart = await _context.BasketItems.Where(x => x.UserID == ID).Include(product => product.Product).ToListAsync();

            await _email.SendEmailAsync(user.Email,"Order Completed", $"<h1>Welcome, {user.FirstName}!</h1>  <p>Thank you for shopping with Cook&&Code.  Your items are on the way!</p>");

            return View(shoppingCart);
        }
    }
}