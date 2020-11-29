using Internet_Restaurant.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_Restaurant.Data.Interfaces
{
    public interface IDishCategory
    {
        IEnumerable<DishCategory> Categories { get; }
    }
}
