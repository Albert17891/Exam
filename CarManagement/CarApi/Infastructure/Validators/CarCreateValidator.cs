using CarApi.Model.Request;
using FluentValidation;

namespace CarApi.Infastructure.Validators
{
    public class CarCreateValidator:AbstractValidator<CarCreateRequest>
    {
        public CarCreateValidator()
        {
            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Enter Model");
            RuleFor(x => x.Dateofmanufac)
                .NotEmpty()
                .WithMessage("Enter Dateofmanufacture");
            RuleFor(x => x.CarInform)
                .NotEmpty()
                .WithMessage("Enter CarInform");
            RuleFor(x => x.CarPrice)
                .NotEmpty()
                .WithMessage("Enter Carprice");
            RuleFor(x => x.Currency)
                .NotEmpty()
                .WithMessage("Enter Currency");
          


           
        }
    }
}
