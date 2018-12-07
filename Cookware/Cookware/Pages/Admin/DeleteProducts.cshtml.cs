using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cookware.Pages.Admin
{
    public class DeleteProductsModel : PageModel
    {
        private readonly IProducts _product;

        public DeleteProductsModel(IProducts product)
        {
            _product = product;
        }

        [BindProperty]
        public Cookware.Models.Product Product { get; set; }

        /// <summary>
        /// Grabs Product by ID to display
        /// </summary>
        /// <param name="ID">Product ID</param>
        /// <returns>display page for delete</returns>
        public async Task<IActionResult> OnGet(int? ID)
        {
            if (ID == null)
            {
                return RedirectToPage("./Index");
            }

            Product = await _product.GetProduct(ID);

            if(Product == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        /// <summary>
        /// Deletes the product related to the id passed in
        /// </summary>
        /// <param name="ID">Product ID</param>
        /// <returns>Index page displaying all products</returns>
        public async Task<IActionResult> OnPost(int ID)
        {
            await _product.DeleteProduct(ID);

            return RedirectToPage("./Index");
        }
    }
}