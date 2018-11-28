using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Data;
using Cookware.Models;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cookware.Controllers
{
    public class BasketItemController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private CookwareDBContext _context;
        private readonly IProducts _products;
        private readonly IBasketItem _basketItem;

        public BasketItemController(UserManager<ApplicationUser> userManager, IProducts products, IBasketItem basketItem, CookwareDBContext context)
        {
            _userManager = userManager;
            _products = products;
            _basketItem = basketItem;
            _context = context;      
        }

        /// <summary>
        /// adds basket item and relates product to user with quantity
        /// </summary>
        /// <param name="ProductID">Id for product being added</param>
        /// <param name="Quantity">quantity of item selected by user</param>
        /// <returns>Index view of product controller</returns>
        [HttpPost, ActionName("AddToCart")]
        public async Task<IActionResult> CreateBasketItem(int ProductID, int Quantity)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var ID = user.Id;
            var basketItem = _context.BasketItems.SingleOrDefault(
                b => b.ProductID == ProductID && b.UserID == ID);
            if (basketItem == null)
            {
                BasketItem newItem = new BasketItem()
                {
                    ProductID = ProductID,
                    Quantity = Quantity,
                    UserID = _userManager.GetUserId(User)
                };

                await _basketItem.CreateBasketItem(newItem);
            }

            else
            {
                basketItem.Quantity++;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> ViewBasket()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var ID = user.Id;
            var shoppingCart = await _context.BasketItems.Where(x => x.UserID == ID).ToListAsync();

            return View(shoppingCart);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteBasketItem(int ProductID)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var ID = user.Id;
                
            await _basketItem.DeleteBasketItem(ProductID, ID);
            return RedirectToAction(nameof(Index));

        }

        private bool ProductExists(int id)
        {
            return _products.GetProduct(id) != null;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var ID = user.Id;
            var shoppingCart = await _context.BasketItems.Where(x => x.UserID == ID).Include(product => product.Product).ToListAsync();
           
            return View(shoppingCart);
        }


    }
}