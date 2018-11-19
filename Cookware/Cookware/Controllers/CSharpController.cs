using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookware.Controllers
{
    [Authorize(Policy = "FavoriteLanguage")]
    public class CSharpController : Controller
    {
        public IActionResult Index()
        {
            User.Claims.Any(c => c.Type == "FavoriteLanguage" && c.Value == "C#");
            bool lang = User.Claims.Any(c => c.Type == "FavoriteLanguage" && c.Value == "C#");
            return View();
        }

    }
}