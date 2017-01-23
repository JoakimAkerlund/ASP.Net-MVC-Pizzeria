using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomasos.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public ShoppingCartDetails ShoppingCartDetails { get; set; }
    }
}
