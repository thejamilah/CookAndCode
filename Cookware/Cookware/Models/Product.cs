using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cookware.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name="SKU Number")]
        public string Sku { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }

        //
        public ICollection<BasketItem> BasketItems { get; set; }

    }
}
