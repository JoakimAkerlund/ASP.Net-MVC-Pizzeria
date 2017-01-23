using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomasos.Models
{
    public class ShoppingCartDetails
    {
        public int ID { get; set; }
        public int ShoppingCartID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Dish Dish { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
