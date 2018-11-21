using Cookware.Data;
using Microsoft.AspNetCore.Mvc;
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

        public IViewComponentResult InvokeAsync()
        {
            var shoppingCart = _context.BasketItems.ToList();

            return View(shoppingCart);

        }
    }
}
