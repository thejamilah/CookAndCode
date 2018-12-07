using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Models;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cookware.Pages.Admin
{
    public class EditProductsModel : PageModel
    {
        private readonly IProducts _product;

        public EditProductsModel(IProducts product)
        {
            _product = product;
        }

        [BindProperty]
        public Cookware.Models.Product Product { get; set; }

        /// <summary>
        /// Grabs Product to display for edit
        /// </summary>
        /// <param name="ID">Product id</param>
        /// <returns>View page for editing product</returns>
        public async Task<IActionResult> OnGet(int? ID)
        {
            if (ID == null)
            {
                return RedirectToPage("./Index");
            }

            Product = await _product.GetProduct(ID);

            if (Product == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        /// <summary>
        /// Updates the product information
        /// </summary>
        /// <returns>Index page displaying all products</returns>
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Page();
            }

            await _product.UpdateProduct(Product);

            return RedirectToPage("./Index");
        }
    }
}