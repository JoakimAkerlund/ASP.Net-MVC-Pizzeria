using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomasos.Data;

namespace Tomasos.Models
{
    public class DishRepository:IDishRepository
    {
        private ApplicationDbContext context;
        
        public DishRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public static List<ShoppingCartDetails> ShoppingCartDetailsList = new List<ShoppingCartDetails>();
        public List<ShoppingCartDetails> GetShoppingCartList()
        {
            return ShoppingCartDetailsList;
        }
        public void ClearShoppingCartList()
        {
            ShoppingCartDetailsList.Clear();
        }
        public void AddDishes(Dish dish)
        {
            ShoppingCartDetailsList.Add(new ShoppingCartDetails
            {
                Dish = dish,
                Price=dish.Price,
                Quantity=1
            });



            //return ShoppingCartDetailsList;
        }

        public int countProductsInShoppingCart()
        {
            return (ShoppingCartDetailsList.Sum(x=>x.Quantity));
        }

        public decimal TotalCost()
        {
            return (ShoppingCartDetailsList.Sum(x => x.Price));
        }

        public void SaveOrder(string userName)
        {
            var customer = context.Customer.SingleOrDefault(c => c.Email == userName);
            int amount = ShoppingCartDetailsList.Sum(x => x.Quantity);
            if (amount > 0)
            {
                context.ShoppingCart.Add(new ShoppingCart
                {
                    CustomerID=customer.ID,
                    Date = DateTime.Now
                });
                context.SaveChanges();

            }           
            

            foreach (var shoppingcartdetail in ShoppingCartDetailsList)
            {
                    context.ShoppingCartDetails.Add(new ShoppingCartDetails{  
                    DishID = shoppingcartdetail.Dish.DishID,               
                    Quantity = shoppingcartdetail.Quantity,
                    Price = shoppingcartdetail.Price,
                    CustomerLink = customer.ID,                   

                });
                
            };
            context.SaveChanges();

        }

        public IEnumerable<Dish> Dishs => context.Dish;
    }
    public interface IDishRepository
    {
        List<ShoppingCartDetails> GetShoppingCartList();
        IEnumerable<Dish> Dishs { get; }
        void AddDishes(Dish dish);
        int countProductsInShoppingCart();
        decimal TotalCost();
        void SaveOrder(string userName);
        void ClearShoppingCartList();
        
    }
}
