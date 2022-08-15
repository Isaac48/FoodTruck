using FoodTruck.DAL;
using FoodTruck.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FoodTruck.BL
{
    public class FoodTruckBL
    {
        private FoodTruckDAL _foodTruckDAL;
        public FoodTruckBL(FoodTruckDAL foodTruckDAL)
        {
            _foodTruckDAL = foodTruckDAL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object FoodTruck(FoodTruckModel model)
        {
            FoodTruckRequesModel request = new FoodTruckRequesModel()
            {
                Dia = model.Dia,
                Hora = model.Hora+":"+model.Minutos,
                OrderType = $"&$order=applicant ASC",
                Where = "$where=",
                UriBase = "https://data.sfgov.org/resource/jjew-r69b.json?",
            };
            var result = _foodTruckDAL.FoodTruckRequest(request);
            return result;
        }

        
    }
}
