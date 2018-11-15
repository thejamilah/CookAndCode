using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Models;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cookware.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProducts _products;

        public ProductController(IProducts products)
        {
            _products = products;
        }

        //Index shows all products
        public async Task<IActionResult> Index()
        {
            return View(await _products.GetProducts());
        }

        //Details for one product
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
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

        //displays view with form
        public IActionResult Create()
        {
            return View();
        }

        //creates product after form submitted
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

        //displays view with form to edit product
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

        //actually performs the action to edit
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

        //displays view with form to delete
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

        //actually deletes product from database
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