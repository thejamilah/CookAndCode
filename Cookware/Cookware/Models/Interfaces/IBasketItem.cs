using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cookware.Models.Interfaces
{
    public interface IBasketItem
    {
        //Create
        Task CreateBasketItem(BasketItem basketItem);

        //Read
        Task<IEnumerable<BasketItem>> GetBasketItems();

        Task<BasketItem> GetBasketItem(int? id);

        //Update
        Task UpdateBasketItem(BasketItem basketItem);

        //Delete
        Task DeleteBasketItem(int id);
    }
}
