using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Data;
using Cookware.Models;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cookware.Pages.Admin
{
    public class RecentOrdersModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private CookwareDBContext _context;
        private readonly IProducts _products;
        private readonly IBasketItem _basketItem;

        [BindProperty]
        public List<Order> Orders { get; set; } = new List<Order>();

        [BindProperty]
        public string UserData { get; set; }


        public RecentOrdersModel(UserManager<ApplicationUser> userManager, IProducts products, IBasketItem basketItem, CookwareDBContext context)
        {
            _userManager = userManager;
            _products = products;
            _basketItem = basketItem;
            _context = context;
        }


        public async Task<IActionResult> OnGet(string uID)
        {
            Orders = await _context.Orders.OrderByDescending
                (i => i.ID)
                .Take(10)
                .ToListAsync();

            return Page();

        }

    }
}