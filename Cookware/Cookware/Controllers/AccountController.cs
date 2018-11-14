using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookware.Controllers
{
    public class AccountController : Controller 
    {
        [HttpGet]
        public async Task<IActionResult> Login(LoginViewModel loginvm)
        {
            if(ModelState.IsValid)
            {
                RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelErro(string.Empty, "Are you sure you entered the right info?");
            }
        }
    }
}
