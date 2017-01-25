using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tomasos.Data;
using Microsoft.AspNetCore.Identity;
using Tomasos.Models;
using Tomasos.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Tomasos.Controllers
{
    public class DishController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IDishRepository repository;
        
        public DishController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager,
                                SignInManager<ApplicationUser> signInManager,
                                IDishRepository repo)
        {
            repository = repo;
            _context = context;
            _userManager = usermanager;
            _signInManager = signInManager;
            this.repository = new DishRepository(_context);
        }
        
        public IActionResult Index()
        {
            ViewData["Title"] = "Tomasos Pizzeria";
            ViewData["Message"] = "Välkommen";
            ViewData["ShoppingCartQuantity"] = repository.countProductsInShoppingCart();
            ViewData["ShoppingCartPrice"] = repository.TotalCost();
            
            return View(repository.Dishs.OrderBy(d => d.Category));
        }             

        public IActionResult Error()
        {
            return View();
        }
    }
}
