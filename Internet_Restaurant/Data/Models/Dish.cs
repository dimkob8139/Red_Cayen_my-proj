using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_Restaurant.Data.Models
{
    public class Dish
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public double weight { get; set; }

        public string img { get; set; }

        public ushort price { get; set; }

        public int categoryId { get; set; }

        public virtual DishCategory Category { get; set; }
    }
}
