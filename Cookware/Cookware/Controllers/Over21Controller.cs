using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookware.Controllers
{
    [Authorize(Policy = "MustBe21ToPurchase")]

    public class Over21Controller : Controller
    {
        /// <summary>
        /// Displays home page of +21 products
        /// </summary>
        /// <returns>To home view</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}