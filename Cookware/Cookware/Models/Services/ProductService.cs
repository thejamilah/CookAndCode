using Cookware.Data;
using Cookware.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookware.Models.Services
{
    public class ProductService : IProducts
    {
        private CookwareDBContext _context;

        public ProductService(CookwareDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds new product into DB
        /// </summary>
        /// <param name="product">new product to be added</param>
        /// <returns>Task but really just adds to db</returns>
        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete product from DB
        /// </summary>
        /// <param name="id">Id for product to delete</param>
        /// <returns>Task for deleted product</returns>
        public async Task DeleteProduct(int id)
        {
            Product product = await GetProduct(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves product from DB
        /// </summary>
        /// <param name="id">Id for reference</param>
        /// <returns>Product requested by id</returns>
        public async Task<Product> GetProduct(int? id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.ID == id);
        }

        /// <summary>
        /// Get list of all products in DB
        /// </summary>
        /// <returns>list of products</returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Updates product in db
        /// </summary>
        /// <param name="product">Product with altered information</param>
        /// <returns>task for updated product</returns>
        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
