using CityAPI.DB;
using CityAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CityAPI.Services
{
    public class CityByVehicle : ICityByVehicle
    {
        private readonly ConnectionToDB _connectionToDB;

        public CityByVehicle(ConnectionToDB connectionToDB)
        {
            _connectionToDB = connectionToDB;
        }

        public City_dto AddCity(City city)
        {
            City_dto city_Dto = new City_dto();

            if (city is null)
            {
                throw new NotImplementedException();
            }
            city.id = Guid.NewGuid(); // only if we not work in dto
            _connectionToDB.cities.Add(city);
            city_Dto.id = city.id;
            city_Dto.name = city.name;
            city_Dto.population = city.population;
            var List = _connectionToDB.vehicles.Where(p => p.min_population < city.population && p.max_population < city.population).Select(s => s.vehicle).First();
            city_Dto.common_vehicle = List;
            _connectionToDB.city_Dtos.Add(city_Dto);
           _connectionToDB.SaveChanges();
            return city_Dto;
        }
        public List<City_dto> GetCityDtoRandom()
        {
            Random rnd = new Random();
            int i = rnd.Next(0, _connectionToDB.city_Dtos.Count());
            var return_data = _connectionToDB.city_Dtos.Skip(i).Take(1).ToList();
            return return_data;
        }
        public List<City_dto> GetCityDtoVehicle(Vehicle vehicle) // only name not typ vehicle
        {
            if (vehicle is null)
            {
                throw new NotImplementedException();
            }
            var seek = _connectionToDB.city_Dtos.Where(p => p.common_vehicle.Contains(vehicle.vehicle)).ToList();
            return seek;
        }
        public List<City_dto> GetCityDto(City_dto city_Dto)// only name not typ city_dto
        {
            if (city_Dto is null)
            {
                throw new NotImplementedException();
            }
            var seek = _connectionToDB.city_Dtos.Where(p => p.common_vehicle.Contains(city_Dto.common_vehicle)).ToList();
            return seek;
        }
        public bool AddVehicle(Vehicle vehicle)
        {
            if (vehicle is null)
            {
                throw new NotImplementedException();
            }
            _connectionToDB.vehicles.Add(vehicle);
            _connectionToDB.SaveChanges();
            return true;
        }
    }
}
