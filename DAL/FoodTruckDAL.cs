using FoodTruck.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FoodTruck.DAL
{

    public class FoodTruckDAL
    {
        /// <summary>
        /// Método que hace la peticion hacia Mobile Food Schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<FoodTruckResultModel> FoodTruckRequest(FoodTruckRequesModel model)
        {
            List<FoodTruckResultModel> list = new List<FoodTruckResultModel>();
            string url = model.UriBase + $"{model.Where} start24 <= '{model.Hora}' AND end24 > '{model.Hora}' AND dayofweekstr = '{model.Dia}'{model.OrderType}";
            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);
            foreach (var item in m)
            {
                FoodTruckResultModel result = new FoodTruckResultModel()
                {
                    Location = item.location,
                    Name = item.applicant
                };
                list.Add(result);
            }
            return list;
        }
    }
}
