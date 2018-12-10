using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookware.Controllers
{
    [AllowAnonymous]
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