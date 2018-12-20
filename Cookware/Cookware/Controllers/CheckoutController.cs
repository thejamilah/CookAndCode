﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookware.Data;
using Cookware.Models;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Cookware.Controllers
{
    [Authorize(Roles = "Member")]
    public class CheckoutController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private CookwareDBContext _context;
        private readonly IOrder _order;
        private readonly IEmailSender _email;
        private readonly IBasketItem _basketItem;

        public CheckoutController(UserManager<ApplicationUser> userManager, CookwareDBContext context, IOrder order, IEmailSender email, IBasketItem basketItem)
        {
            _userManager = userManager;
            _context = context;
            _email = email;
            _order = order;
            _basketItem = basketItem;
        }

        /// <summary>
        /// shows index page for checkout
        /// </summary>
        /// <returns>view</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Checkout page which accepts credit card information
        /// </summary>
        /// <param name="CreditCard">Test credit card number</param>
        /// <returns>Receipt Page</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Checkout(string CreditCard, string FirstName, string LastName)
        {
            //get credit card number, last four digits
            string ccNumber = CreditCard;
            string lastFourDigits = ccNumber.Substring(ccNumber.Length - 4, 4);

            //get user
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var ID = user.Id;
            
            //get basket items
            var shoppingCart = await _context.BasketItems.Where(x => x.UserID == ID && x.OrderID == 1).Include(product => product.Product).ToListAsync();

            //get total
            decimal total = 0;
            foreach(var item in shoppingCart)
            {
                total += item.Product.Price;
                
            }

            //create new order item
            Order order = new Order()
            {
                UserID = ID,
                FirstName = FirstName,
                LastName = LastName,
                OrderDate = DateTime.Now,
                CreditCard = Convert.ToInt32(lastFourDigits),
                Total = total
            };

            await _order.CreateOrder(order);

            foreach( var item in shoppingCart)
            {
                item.OrderID = order.ID;
                await _basketItem.UpdateBasketItem(item);
            }


            return RedirectToAction("Receipt", "Checkout");
        }

        /// <summary>
        /// Sends email upon checkout for completion of order and redirects to receipt page
        /// </summary>
        /// <returns> shopping cart receipt page</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Receipt()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var ID = user.Id;

            var order = await _order.GetLastOrder();

            var shoppingCart = await _context.BasketItems.Where(x => x.UserID == ID && x.OrderID == order.ID).Include(product => product.Product).ToListAsync();

            await _email.SendEmailAsync(user.Email,"Order Completed", $"<h1>Welcome, {user.FirstName}!</h1>  <p>Thank you for shopping with Cook&&Code.  Your items are on the way!</p>");

            return View(shoppingCart);
        }
    }
}