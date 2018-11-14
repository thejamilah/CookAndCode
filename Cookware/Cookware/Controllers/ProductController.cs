using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cookware.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProducts _products;

        //Index shows all products
        public IActionResult Index()
        {
            return View();
        }

        //Details for one product
        public IActionResult Details(int? id)
        {
            return View();
        }

        //displays view with form
        public IActionResult Create()
        {
            return View();
        }

        //creates product after form submitted
        public IActionResult CreateProduct()
        {
            return View();
        }

        //displays view with form to edit product
        public IActionResult Edit(int? id)
        {
            return View();
        }

        //actually performs the action to edit
        [HttpPost]
        public IActionResult Edit(int? id, Product product)
        {
            return View();
        }

        //displays view with form to delete
        public IActionResult DeleteProduct(int? id)
        {
            return View();
        }

        //actually deletes product from database
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteProduct(int id)
        {
            return View();
        }
    }
}