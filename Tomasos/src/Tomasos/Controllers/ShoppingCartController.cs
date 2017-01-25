using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tomasos.Data;
using Tomasos.Models;
using Microsoft.AspNetCore.Identity;
using Tomasos.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Tomasos.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IDishRepository repository;
        public ShoppingCartController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager,
                                SignInManager<ApplicationUser> signInManager,
                                IDishRepository repo)
        {
            repository = repo;
            _context = context;
            _userManager = usermanager;
            _signInManager = signInManager;
            this.repository = new DishRepository(_context);
        }
        [Route("ShoppingCart")]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AddDish(int dishID)
        {
            if (_signInManager.IsSignedIn(User))
            {
                //var customer = _context.Customer.Where(c => c.Email == User.Identity.Name);                       
                var dish = _context.Dish.SingleOrDefault(d => d.DishID == dishID);
                repository.AddDishes(dish);
                ViewData["ShoppingCartQuantity"] = repository.countProductsInShoppingCart();
                ViewData["ShoppingCartPrice"] = repository.TotalCost();
                return RedirectToAction("Index","Dish", repository.Dishs.OrderBy(d => d.Category));
            }
            
            return View();
        }
        public IActionResult Checkout()
        {
            if (_signInManager.IsSignedIn(User))
            {
               var userName= _userManager.GetUserName(User);
                repository.SaveOrder(userName);
            }
            var list = repository.GetShoppingCartList().ToList();
            repository.ClearShoppingCartList();
            return View(list);
        }
    }
}
