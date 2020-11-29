using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internet_Restaurant.Data.Interfaces;
using Internet_Restaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Internet_Restaurant.Controllers
{
    public class MainController : Controller
    {
        private IAllDishes dishRep;

        public MainController(IAllDishes dishRep)
        {
            this.dishRep = dishRep;
        }
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
