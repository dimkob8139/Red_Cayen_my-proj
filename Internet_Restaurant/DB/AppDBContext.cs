using Internet_Restaurant.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_Restaurant.Data
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<DishCategory> Category { get; set; }
        //public DbSet<DishCartItem> ShopCartItem { get; set; }
        //public DbSet<Order> Order { get; set; }
        //public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
