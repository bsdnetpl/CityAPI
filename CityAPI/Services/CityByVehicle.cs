using AutoMapper;
using CityAPI.DB;
using CityAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CityAPI.Services
{
    public class CityByVehicle : ICityByVehicle
    {
        private readonly ConnectionToDB _connectionToDB;
        private readonly IMapper _mapper;
        public CityByVehicle(ConnectionToDB connectionToDB, IMapper mapper)
        {
            _connectionToDB = connectionToDB;
            _mapper = mapper;
        }

        public City_dto AddCity(City city)
        {
            if (city is null)
            {
                throw new NotImplementedException();
            }
            city.id= Guid.NewGuid();
            var result = _mapper.Map<City_dto>(city);
            var List = _connectionToDB.vehicles.Where(p => p.min_population <= city.population && p.max_population >= city.population).Select(s => s.vehicle).First();
            result.common_vehicle = List;
            _connectionToDB.city_Dtos.Add(result);
            _connectionToDB.cities.Add(city);
            _connectionToDB.SaveChanges();
            return result;
        }
        public List<City_dto> GetCityDtoRandom()
        {
            Random rnd = new Random();
            int i = rnd.Next(0, _connectionToDB.city_Dtos.Count());
            var return_data = _connectionToDB.city_Dtos.Skip(i).Take(1).ToList();
            return return_data;
        }
        public List<City_dto> GetCityDtoVehicle(string vehicle) 
        {
            if (vehicle is null)
            {
                throw new NotImplementedException();
            }
            var seek = _connectionToDB.city_Dtos.Where(p => p.common_vehicle == vehicle).ToList();
            return seek;
        }
        public List<City_dto> GetCityDto(string NameDto)// only name not typ city_dto
        {
            if (NameDto is null)
            {
                throw new NotImplementedException();
            }
            var seek = _connectionToDB.city_Dtos.Where(p => p.common_vehicle == NameDto).ToList();
            return seek;
        }
        public bool AddVehicle(Vehicle vehicle)
        {
            if (vehicle is null)
            {
                throw new NotImplementedException();
            }
            vehicle.Id = Guid.NewGuid();
            _connectionToDB.vehicles.Add(vehicle);
            _connectionToDB.SaveChanges();
            return true;
        }
    }
}
