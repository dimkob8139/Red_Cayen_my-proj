using Internet_Restaurant.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_Restaurant.ViewModels
{
    public class MainViewModel
    {
        public IEnumerable<Dish> allDishes { get; set; }
    }
}
