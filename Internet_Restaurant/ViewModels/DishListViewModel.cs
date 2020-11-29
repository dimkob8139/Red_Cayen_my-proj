using System;
using Internet_Restaurant.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_Restaurant.ViewModels
{
    public class DishListViewModel
    {
        public IEnumerable<Dish> allDishes { get; set; }
        public string currCategory { get; set; }
    }
}
