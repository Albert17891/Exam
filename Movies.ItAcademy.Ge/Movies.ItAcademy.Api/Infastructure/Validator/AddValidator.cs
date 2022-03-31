using FluentValidation;
using Movies.ItAcademy.Api.Infastructure.ErrorMessages;
using Movies.ItAcademy.Api.Infastructure.Extensions;
using Movies.ItAcademy.Api.Models.Requests;

namespace Movies.ItAcademy.Api.Infastructure.Validator

{
    public class AddValidator : AbstractValidator<Register>
    {
        public AddValidator()
        {
            RuleFor(x => x.FirstName)
                 .NotEmpty()
                 .WithMessage(ErrorMessage.FirstName);

            RuleFor(x => x.LastName)
                 .NotNull()
                 .WithMessage(ErrorMessage.LastName);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage(ErrorMessage.Email);

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage(ErrorMessage.UserName);

            RuleFor(x => x.Password)
                .Password();

            RuleFor(x => x.ConfirmPassword)
              .Equal(x => x.Password)
              .WithMessage(ErrorMessage.ConfirmPassword);
        }
    }
}
