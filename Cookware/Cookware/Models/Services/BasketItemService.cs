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

        public async Task CreateBasketItem(BasketItem basketItem)
        {
            _context.BasketItems.Add(basketItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBasketItem(int ProductID, string ID)
        {
            BasketItem basketItem = await GetBasketItem(ProductID, ID);
            _context.BasketItems.Remove(basketItem);
            await _context.SaveChangesAsync();
        }

        public async Task<BasketItem> GetBasketItem(int ProductID, string ID)
        {
            return await _context.BasketItems
                .FirstOrDefaultAsync(x => x.ProductID == ProductID && x.UserID == ID);

           
        }

        public async Task<IEnumerable<BasketItem>> GetBasketItems()
        {
            return await _context.BasketItems.ToListAsync();
        }

        public async Task UpdateBasketItem(BasketItem basketItem)
        {
            _context.BasketItems.Update(basketItem);
            await _context.SaveChangesAsync();
        }
    }
}
