using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Models;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cookware.Controllers
{   

    [AllowAnonymous]
    public class ProductController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IProducts _products;
        private readonly IBasketItem _basketItem;

        public ProductController(UserManager<ApplicationUser> userManager, IProducts products, IBasketItem basketItem)
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
            return View(await _products.GetProducts());
        }

        /// <summary>
        /// Details for one product
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Product Detail</returns>
        [HttpPost]
        public async Task<IActionResult> Details(int? productID)
        {
            if(productID == null)
            {
                return NotFound();
            }

            var product = await _products.GetProduct(productID);
            if(product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// displays view with form
        /// </summary>
        /// <returns>Created product view</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// creates product after form submitted
        /// </summary>
        /// <param name="product">New Product Object</param>
        /// <returns>Created product view</returns>
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID, Sku, Name, Price, Description, Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _products.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        /// <summary>
        /// displays view with form to edit product
        /// </summary>
        /// <param name="id">Gets product by ID to edit</param>
        /// <returns>Updated product</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _products.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        /// <summary>
        /// actually performs the action to edit
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <param name="product">Edited product name</param>
        /// <returns>Redirect to home</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("ID, Sku, Name, Price, Description, Image")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _products.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        /// <summary>
        /// displays view with form to delete
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Deleted view</returns>
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _products.GetProduct(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        /// <summary>
        /// actually deletes product from database
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Redirect to home</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _products.DeleteProduct(id);
            return RedirectToAction(nameof(Index));

        }

        private bool ProductExists(int id)
        {
            return _products.GetProduct(id) != null;
        }

    }
}