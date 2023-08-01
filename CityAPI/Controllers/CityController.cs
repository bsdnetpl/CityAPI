using CityAPI.Models;
using CityAPI.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityByVehicle _cityByVehicle;
        private readonly IValidator<City> _validatorCity;
        private readonly IValidator<City_dto> _validatorCityDto;
        private readonly IValidator<Vehicle> _validateVehicle;

        public CityController(ICityByVehicle cityByVehicle, IValidator<City> validatorCity, IValidator<City_dto> validatorCityDto, IValidator<Vehicle> validateVehicle)
        {
            _cityByVehicle = cityByVehicle;
            _validatorCity = validatorCity;
            _validatorCityDto = validatorCityDto;
            _validateVehicle = validateVehicle;
        }

        [HttpGet("Get_city_dto")]
        public ActionResult <List<City_dto>> GetCityDto(string name)
        {
            if (ModelState.IsValid)
            {

                return Ok(_cityByVehicle.GetCityDto(name));
            }
            return NotFound();
        }
        [HttpGet("Get_city_dto_random")]
        public ActionResult<List<City_dto>> GetCityDtoRandom()
        {
            if (ModelState.IsValid)
            {
                return Ok(_cityByVehicle.GetCityDtoRandom());
            }
            return NotFound();
        }
        [HttpGet("Get_city_dto_vehicle")]
        public ActionResult<List<City_dto>> GetCityDtoVehicle(string cityDto)
        {
            if (ModelState.IsValid)
            {
                return _cityByVehicle.GetCityDtoVehicle(cityDto);
            }
            return NotFound();
        }
        [HttpPost("Add_city")]
        public ActionResult<City_dto> AddCity(City city)
        {
            if (ModelState.IsValid)
            {
                return _cityByVehicle.AddCity(city);
            }
            return NotFound();
        }
        [HttpPost("Add_Vehicle_per_population")]
        public ActionResult <bool> AddVehicle(Vehicle vehicle)
        {
            ValidationResult result = _validateVehicle.Validate(vehicle);
            if (result.IsValid)
            {
                return Ok(_cityByVehicle.AddVehicle(vehicle));
            }
            return NotFound();

        }
    }
}
