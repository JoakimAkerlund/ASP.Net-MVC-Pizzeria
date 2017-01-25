using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tomasos.Models
{
    public class Dish
    {
        [Key]
        public int DishID { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
