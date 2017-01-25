using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tomasos.Models
{
    public class ShoppingCartDetails
    {
        [Key]
        public int ShoppingCartDetailsID { get; set; }
        public int DishID { get; set; }
        public int CustomerLink { get; set; }        
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Dish Dish { get; set; }


    }
    
}
