using Internet_Restaurant.Data.Interfaces;
using Internet_Restaurant.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_Restaurant.Data.Repository
{
    public class DishCategoryRepository : IDishCategory
    {
        private readonly AppDbContext context;
        public DishCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<DishCategory> Categories => context.Category;
    }
}
