using FluentValidation;
using System;

namespace CityAPI.Models
{
    public class City
    {
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public int population { get; set; }
    }

    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(x => x.id).NotNull().WithMessage("This variable (id) cannot be empty !");
            RuleFor(x => x.name).Length(0, 10).NotNull().WithMessage("This variable (name) cannot be empty !");
            RuleFor(x => x.population).NotNull().WithMessage("This variable (population) cannot be empty !");
        }
    }
}
