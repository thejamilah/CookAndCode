using Cookware.Data;
using Cookware.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Creates new order object
        /// </summary>
        /// <param name="Order">New Order to be added to DB</param>
        /// <returns>Task for order item</returns>
        public async Task CreateOrder(Order Order)
        {
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get list of top 5 orders in DB for user
        /// </summary>
        /// <returns>list of products</returns>
        public async Task<IEnumerable<Order>> GetTopFiveOrders(string userID)
        {
            var orders = await _context.Orders.Include(bi => bi.BasketItems).ThenInclude(p => p.Product).Where(x => x.UserID == userID).Take(5).ToListAsync();
            return orders;
        }

        /// <summary>
        /// Gets the last order that was added to the db
        /// </summary>
        /// <returns>last order in db for user</returns>
        public async Task<Order> GetLastOrder()
        {
            return await _context.Orders.OrderByDescending(order => order.OrderDate).FirstOrDefaultAsync();
        }
    }
}
