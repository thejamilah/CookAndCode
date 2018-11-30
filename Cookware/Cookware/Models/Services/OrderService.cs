using Cookware.Data;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookware.Models.Services
{
    public class OrderService : IOrder
    {
        private CookwareDBContext _context;
        private UserManager<ApplicationUser> _userManager;

        public OrderService(CookwareDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task CreateOrder(Order Order)
        {
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();
        }
    }
}
