using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Web;
using Internet_Restaurant.Data.Models;
using Internet_Restaurant.Data;

namespace Internet_Restaurant.DB
{
    public class AppDbInitializer
    {

        public static void Initial(AppDbContext context)
        {
            if (!context.Category.Any())
            {
                context.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Dish.Any())
            {
                context.AddRange(
                    new Dish
                    {
                       
                        name = "Маргарита",
                        description = "Самая вкусная пицца в мире",
                        weight = 300,
                        price = 127,
                        img = "/images/pizza_margarita.jpg",
                        Category = Categories["Пиццы"]
                    },
                    new Dish
                    {
                      
                        name = "Цезарь",
                        description = "Самый вкусный салат в мире",
                        weight = 150,
                        price = 60,
                        img = "/images/salad_cezar.jpg",
                        Category = Categories["Салаты"]
                    }


                    );
            }
            context.SaveChanges();

        }
        private static Dictionary<string, DishCategory> category;
        public static Dictionary<string, DishCategory> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new DishCategory[]
                    {
                        new DishCategory{ categoryName ="Пиццы" , categoryDescription ="Самые вкусные наши пиццы"},
                    new DishCategory{ categoryName ="Салаты" , categoryDescription ="Самые вкусные наши салаты"}
                    };
                    category = new Dictionary<string, DishCategory>();
                    foreach (DishCategory el in list)
                        category.Add(el.categoryName, el);
                }
                return category;
            }
        }

    }
}
