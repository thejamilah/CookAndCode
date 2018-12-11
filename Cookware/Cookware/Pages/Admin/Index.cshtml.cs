using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cookware.Pages.Admin
{
    [Authorize("AdminAccess")]
    public class IndexModel : PageModel
    {

        private readonly IProducts _product;

        public IndexModel(IProducts product)
        {
            _product = product;
        }

        public IEnumerable<Cookware.Models.Product> Products { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Products = await _product.GetProducts();
            return Page();
        }
    }
}