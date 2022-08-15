using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Models
{
    public class FoodTruckRequesModel
    {
        public string Dia { get; set; }
        public string Hora { get; set; }

        public string OrderType { get; set; }

        public string Where { get; set; }

        public string UriBase { get; set; }
    }
}
