using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomasos.Models
{
    public class Dish
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
