using Internet_Restaurant.Data.Interfaces;
using Internet_Restaurant.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_Restaurant.Data.Repository
{
    public class DishRepository : IAllDishes
    {
        private readonly AppDbContext context;
        public DishRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Dish> Dishes => context.Dish.Include(c => c.Category);

        public Dish getObjectDish(int dishId)
        {
            return context.Dish.FirstOrDefault(p => p.id == dishId);
        }
    }
}
