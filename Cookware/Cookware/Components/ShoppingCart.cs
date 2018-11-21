using Cookware.Data;
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

        public ShoppingCart(CookwareDBContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var shoppingCart = await _context.BasketItems.ToListAsync();

            return View(shoppingCart);

        }
    }
}
