using CityAPI.Models;

namespace CityAPI.Services
{
    public interface ICityByVehicle
    {
        City_dto AddCity(City city);
        bool AddVehicle(Vehicle vehicle);
        List<City_dto> GetCityDto(City_dto city_Dto);
        List<City_dto> GetCityDtoRandom();
        List<City_dto> GetCityDtoVehicle(Vehicle vehicle);
    }
}