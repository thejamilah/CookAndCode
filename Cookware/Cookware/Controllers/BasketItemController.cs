using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Data;
using Cookware.Models;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cookware.Controllers
{
    [Authorize]
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

            var product = await _products.GetProduct(ProductID);

            var basketItem = _context.BasketItems.SingleOrDefault(
                b => b.ProductID == ProductID && b.UserID == ID && b.OrderID == 1);

            if (basketItem == null)
            {
                BasketItem newItem = new BasketItem()
                {
                    ProductID = ProductID,
                    Quantity = Quantity,
                    UserID = _userManager.GetUserId(User),
                    OrderID = 1
                };

                await _basketItem.CreateBasketItem(newItem);
            }

            else
            {
                basketItem.Quantity++;
            }

            _context.SaveChanges();

            if(product.LanguageIsCSharp == true)
            {
                return RedirectToAction("Index", "CSharp");
            }

            return RedirectToAction("Index", "Product");
        }


        /// <summary>
        /// Deletes basket item based on id passed in
        /// </summary>
        /// <param name="ProductID">Product ID from button</param>
        /// <returns>index page for shopping cart</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteBasketItem(int ProductID)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var ID = user.Id;
                
            await _basketItem.DeleteBasketItem(ProductID, ID);
            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// Checks if product exists
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>true if exists or false if not</returns>
        private bool ProductExists(int id)
        {
            return _products.GetProduct(id) != null;
        }

        /// <summary>
        /// Index page displays basket items associated with user
        /// </summary>
        /// <returns>shopping cart</returns>
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var ID = user.Id;
            var shoppingCart = await _context.BasketItems.Where(x => x.UserID == ID && x.OrderID == 1).Include(product => product.Product).ToListAsync();
           
            return View(shoppingCart);
        }

        /// <summary>
        /// Updates quantity on a basket item from shopping cart view
        /// </summary>
        /// <param name="ID">Basket Item ID</param>
        /// <param name="ProductID">Product ID</param>
        /// <param name="Quantity">Updated Quantity</param>
        /// <returns>shopping cart page</returns>
        [HttpPost, ActionName("Update")]
        public async Task<IActionResult> UpdateBasketItem(int ID, int ProductID, int Quantity)
        {
            BasketItem updateItem = new BasketItem()
            {
                ID = ID,
                ProductID = ProductID,
                Quantity = Quantity,
                UserID = _userManager.GetUserId(User)
            };

            await _basketItem.UpdateBasketItem(updateItem);

            return RedirectToAction(nameof(Index));
        }
    }
}