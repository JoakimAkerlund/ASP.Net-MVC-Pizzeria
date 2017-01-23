using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tomasos.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Tomasos.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext _context;
        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddDish(int dishID)
        {
            var order = _context.Dish.Where(d => d.ID.Equals(dishID));
            return View("_ShoppingCartPartial",order);
        }
    }
}
