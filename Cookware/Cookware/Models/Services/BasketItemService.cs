using Cookware.Data;
using Cookware.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookware.Models.Services
{
    public class BasketItemService : IBasketItem
    {
        private CookwareDBContext _context;

        public BasketItemService(CookwareDBContext context)
        {
            _context = context;
        }

        public async Task CreateBasketItem(BasketItem basketItem)
        {
            _context.BasketItems.Add(basketItem);
            await _context.SaveChangesAsync();
        }     

        public async Task DeleteBasketItem(int id)
        {
            BasketItem basketItem = await GetBasketItem(id);
            _context.BasketItems.Remove(basketItem);
            await _context.SaveChangesAsync();
        }

        public async Task<BasketItem> GetBasketItem(int? id)
        {
            return await _context.BasketItems.FirstOrDefaultAsync(x => x.ID == id);
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
