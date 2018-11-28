using Cookware.Data;
using Cookware.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Cookware.Models.Services
{
    public class BasketItemService : IBasketItem
    {
        private CookwareDBContext _context;
        private UserManager<ApplicationUser> _userManager;

        public BasketItemService(CookwareDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Creates new basket item in db
        /// </summary>
        /// <param name="basketItem">New BasketItem object to be added</param>
        /// <returns>ask for added item</returns>
        public async Task CreateBasketItem(BasketItem basketItem)
        {
            _context.BasketItems.Add(basketItem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete item from db
        /// </summary>
        /// <param name="ProductID">Product id</param>
        /// <param name="ID">User id</param>
        /// <returns>task for deleted item</returns>
        public async Task DeleteBasketItem(int ProductID, string ID)
        {
            BasketItem basketItem = await GetBasketItem(ProductID, ID);
            _context.BasketItems.Remove(basketItem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves basket item by id's
        /// </summary>
        /// <param name="ProductID">Product Id</param>
        /// <param name="ID">User id</param>
        /// <returns>Basket item requested</returns>
        public async Task<BasketItem> GetBasketItem(int ProductID, string ID)
        {
            return await _context.BasketItems
                .FirstOrDefaultAsync(x => x.ProductID == ProductID && x.UserID == ID);
        }

        /// <summary>
        /// Gets all basket items in db
        /// </summary>
        /// <returns>list of basket items</returns>
        public async Task<IEnumerable<BasketItem>> GetBasketItems()
        {
            return await _context.BasketItems.ToListAsync();
        }

        /// <summary>
        /// Updates basket item with object
        /// </summary>
        /// <param name="basketItem">modified basket item object</param>
        /// <returns>task for updated item</returns>
        public async Task UpdateBasketItem(BasketItem basketItem)
        {
            _context.BasketItems.Update(basketItem);
            await _context.SaveChangesAsync();
        }
    }
}
