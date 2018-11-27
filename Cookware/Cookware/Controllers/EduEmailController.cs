using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookware.Controllers
{
    [Authorize(Policy = "SchoolEmail")]
    public class EduEmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}