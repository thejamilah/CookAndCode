using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cookware.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        public string UserID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OrderDate { get; set; }

        public int CreditCard { get; set; }

        public decimal Total { get; set; }

        //Nav prop
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
