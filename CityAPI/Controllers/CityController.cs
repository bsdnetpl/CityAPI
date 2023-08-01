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

        [HttpGet("Get_city_dto")]
        public ActionResult <List<City_dto>> GetCityDto(City_dto city_Dto)
        {
            return Ok(_cityByVehicle.GetCityDto(city_Dto));
        }
        [HttpGet("Get_city_dto_random")]
        public ActionResult<List<City_dto>> GetCityDtoRandom()
        {
         return Ok(_cityByVehicle.GetCityDtoRandom());
        }
        [HttpGet("Get_city_dto_vehicle")]
        public ActionResult <List<City_dto>> GetCityDtoVehicle(Vehicle vehicle)
            {
            return Ok(_cityByVehicle.GetCityDtoVehicle(vehicle));
            }
        [HttpPost("Add_city")]
        public ActionResult<City_dto> AddCity(City city)
        {
            return _cityByVehicle.AddCity(city);
        }
        [HttpPost("Add_Vehicle_per_population")]
        public ActionResult <bool> AddVehicle(Vehicle vehicle)
        {
            return Ok(_cityByVehicle.AddVehicle(vehicle));
        }
    }
}
