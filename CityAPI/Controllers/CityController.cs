using CityAPI.Models;
using CityAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityByVehicle _cityByVehicle;

        public CityController(ICityByVehicle cityByVehicle)
        {
            _cityByVehicle = cityByVehicle;
        }

        //[HttpGet("Get_city_dto")]
        //[HttpGet("Get_city_dto_random")]
        //[HttpGet("Get_city_dto_vehicle")]
        //[HttpPost("Add_city")]
        [HttpPost("Add_Vehicle_per_population")]
        public ActionResult <bool> AddVehicle(Vehicle vehicle)
        {
            return Ok(_cityByVehicle.AddVehicle(vehicle));
        }
    }
}
