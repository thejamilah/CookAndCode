using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookware.Models.Interfaces
{
    public interface IOrder
    {
        //Create
        Task CreateOrder(Order Order);

        //Read
        Task<IEnumerable<Order>> GetTopFiveOrders(string userID);

        Task<Order> GetLastOrder();
    }
}
