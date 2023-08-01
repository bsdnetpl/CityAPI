using FluentValidation;

namespace CityAPI.Models
{
    public class Vehicle
    {
      public Guid Id { get; set; }
      public  int min_population { set; get; } 
      public int max_population { set; get; } 
      public string vehicle { set; get; } = string.Empty;
    }
    public class Vehicle_dtoValidator : AbstractValidator<Vehicle>
    {
        public Vehicle_dtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("This variable (Id) cannot be empty !");
            RuleFor(x => x.vehicle).Length(0, 10).NotNull().WithMessage("This variable (vehicle) cannot be empty !");
            RuleFor(x => x.min_population).NotNull().WithMessage("This variable (m_population) cannot be empty !");
            RuleFor(x => x.max_population).NotNull().WithMessage("This variable (max_population) cannot be empty !");
        }
    }
}
