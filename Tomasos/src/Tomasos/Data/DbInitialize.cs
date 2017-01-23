using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomasos.Models;

namespace Tomasos.Data
{
    public class DbInitialize
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Dish.Any())
            {
                return;
            }
           
            var dishes = new List<Dish>(){
                new Dish() { Title = "Capricciosa", Category = "Pizza", Ingredients = "Tomatsås, Ost, Skinka, Champinjoner", Price = 70 },
            new Dish() { Title = "Kebabtallrik", Category = "Kebab", Ingredients = "Kebabkött, Feferoni, Sallad, Pommes frites, Vitlökssås", Price = 75 },
            new Dish() { Title = "Vesuvio", Category = "Pizza", Ingredients = "Tomatsås, Ost, Skinka", Price = 65 },
            new Dish() { Title = "Calzone", Category = "Pizza", Ingredients = "Tomatsås, Ost, Skinka", Price = 75 },
            new Dish() { Title = "Räksallad", Category = "Sallad", Ingredients = "Räkor, Rhode Islandsås (i burk), Paprika, Ägg, Tomater (färska), Isbergssallad, Gurka, Citron", Price = 70 },
            new Dish() { Title = "Kebab med bröd", Category = "Kebab", Ingredients = "Kebabkött, Feferoni, Sallad, Pommes frites, Vitlökssås", Price = 70 },
            new Dish() { Title = "Tonfisksallad", Category = "Sallad", Ingredients = "Tonfisk, Rhode Islandsås (i burk), Oliver, Lök, Paprika, Tomater(färska), Isbergssallad, Gurka, Citron", Price = 74 },
            new Dish() { Title = "Spaghetti med köttfärssås", Category = "Pasta", Ingredients = "Spaghetti,köttfärsås", Price = 90 },
            new Dish() { Title = "Lasagne", Category = "Pasta", Ingredients = "Köttfärs, Lök, Tomater(färska), Feferoni, Isbergssallad", Price = 90 }
            };
            foreach (var d in dishes)
            {
                context.Dish.Add(d);
            }
            context.SaveChanges();



        }
    }
}

