using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internet_Restaurant.Data;
using Internet_Restaurant.Data.Interfaces;
using Internet_Restaurant.Data.Models;
using Internet_Restaurant.Data.Repository;
using Internet_Restaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Internet_Restaurant.Controllers
{
    public class DishController : Controller
    {
        private readonly IAllDishes allDishes;
        private readonly IDishCategory allCategories;

        public DishController(IAllDishes allDishes, IDishCategory allCategories)
        {
            this.allDishes = allDishes;
            this.allCategories = allCategories;
        }

        [Route("Dishes/List")]
        [Route("Dishes/List/{category}")]

        public IActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Dish> dishes = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                dishes =  allDishes.Dishes.OrderBy(i => i.id);
            }
            var dishObj = new DishListViewModel
            {
                allDishes = dishes,
                currCategory = currCategory
            };
            ViewBag.Title = "Страница с блюдами";
            return View(dishObj);
        }
    }
}
