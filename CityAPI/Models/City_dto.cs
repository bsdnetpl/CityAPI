using FluentValidation;

namespace CityAPI.Models
{
    public class City_dto
    {
         public Guid  id { get; set; }
         public string name { get; set; }
         public int  population { get; set; }  
         public string common_vehicle { get; set; }   
    }
    public class City_dtoValidator : AbstractValidator<City_dto>
    {
        public City_dtoValidator()
        {
            RuleFor(x => x.id).NotNull().WithMessage("This variable (id) cannot be empty !");
            RuleFor(x => x.name).Length(0, 10).NotNull().WithMessage("This variable (name) cannot be empty !");
            RuleFor(x => x.population).NotNull().WithMessage("This variable (population) cannot be empty !");
            RuleFor(x => x.common_vehicle).NotNull().WithMessage("This variable (common_vehicle) cannot be empty !");
        }
    }
}
