using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cookware.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Initial landing page of website
        /// </summary>
        /// <returns>Home view</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}