using AutoMapper;

namespace CityAPI.Models
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<City,City_dto>();
        }      
    }
}
