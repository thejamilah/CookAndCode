using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Models;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cookware.Controllers
{
    [Authorize(Policy = "FavoriteLanguage")]
    public class CSharpController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IProducts _products;
        private readonly IBasketItem _basketItem;

        public CSharpController(UserManager<ApplicationUser> userManager, IProducts products, IBasketItem basketItem)
        {
            _userManager = userManager;
            _products = products;
            _basketItem = basketItem;
        }

        /// <summary>
        /// index shows all products
        /// </summary>
        /// <returns>Product Index</returns>
        public async Task<IActionResult> Index()

        {
            var products = await _products.GetProducts();
            var CSharpProducts = products.Where(x => x.LanguageIsCSharp == true);
            return View(CSharpProducts);
        }

        /// <summary>
        /// Details for one product
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Product Detail</returns>
        [HttpPost]
        public async Task<IActionResult> Details(int? productID)
        {
            if (productID == null)
            {
                return NotFound();
            }

            var product = await _products.GetProduct(productID);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}