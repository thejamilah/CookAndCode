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

        Task<BasketItem> GetBasketItem(int ProductID, string ID);

        //Update
        Task UpdateBasketItem(BasketItem basketItem);

        //Delete
        Task DeleteBasketItem(int ProductID, string ID);
    }
}
