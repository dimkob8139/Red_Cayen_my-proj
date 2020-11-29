using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_Restaurant.Data.Models
{
    public class Table
    {
        public int id { get; set; }
        public int AmountSeat { get; set; }
        public bool IsReserved { get; set; }
        public DateTime dateBooking  { get; set; }
    }
}
