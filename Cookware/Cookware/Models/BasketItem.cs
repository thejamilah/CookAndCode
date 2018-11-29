using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cookware.Models
{
    public class BasketItem
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public string UserID { get; set; }

        public int OrderID { get; set; }

        //Nav keys

        public Product Product { get; set; }

        public Order Order { get; set; }

    }
}
