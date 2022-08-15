using FoodTruck.BL;
using FoodTruck.Logger;
using FoodTruck.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTruckController : ControllerBase
    {
        private ILoggerManager _logger;

        private FoodTruckBL _foodTruckBL;
        public FoodTruckController(FoodTruckBL foodTruckBL, ILoggerManager logger)
        {
            _foodTruckBL = foodTruckBL;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint que resibe la petición desde el FrontEnd de Angular
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetFoodTruck")]
        public IActionResult GetFoodTruck(int hora, int min, string dia)
        {
            try
            {
                FoodTruckModel model = new FoodTruckModel()
                {
                    Dia = dia,
                    Hora = hora <10?"0"+hora.ToString():hora.ToString(),
                    Minutos = min <10?"0"+min.ToString():min.ToString(),
                };
                var foodTruck = _foodTruckBL.FoodTruck(model);
                return Ok(foodTruck);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetFoodTruck)} action { ex}");
                return StatusCode(500, "Internal server error");
            }
           
        }
    }
}
