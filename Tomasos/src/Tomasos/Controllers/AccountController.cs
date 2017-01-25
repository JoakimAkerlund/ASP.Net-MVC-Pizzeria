using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Tomasos.Models;
using Microsoft.AspNetCore.Identity;
using Tomasos.Data;
using Tomasos.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Tomasos.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IDishRepository repository;

        public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager,
                                SignInManager<ApplicationUser> signInManager,
                                IDishRepository repo)
        {
            repository = repo;
            _context = context;
            _userManager = usermanager;
            _signInManager = signInManager;
            this.repository = new DishRepository(_context);
        }
        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Dish");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var customer = new Customer {Name=model.Name,Address=model.Address,Phone=model.Phone, Email = model.Email };
                _context.Customer.Add(customer);
                _context.SaveChanges();
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Dish");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            
            await _signInManager.SignOutAsync();
            repository.ClearShoppingCartList();
            return RedirectToAction("Index", "Dish");
        }
    }
}
