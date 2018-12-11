using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cookware.Pages.Admin
{
    public class CreateProductsModel : PageModel
    {
        private readonly IProducts _product;

        public CreateProductsModel(IProducts product)
        {
            _product = product;
        }

        [BindProperty]
        public Cookware.Models.Product Product { get; set; }

        /// <summary>
        /// Displays page with form to create new product
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            return Page();
        }

        /// <summary>
        /// creates new product
        /// </summary>
        /// <returns>index page displaying all products</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _product.CreateProduct(Product);

            return RedirectToPage("./Index");
        }
    }
}