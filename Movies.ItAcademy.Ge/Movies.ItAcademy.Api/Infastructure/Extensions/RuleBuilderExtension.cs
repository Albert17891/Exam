using FluentValidation;
using Movies.ItAcademy.Api.Infastructure.ErrorMessages;
using Movies.ItAcademy.Api.Models.Requests;

namespace Movies.ItAcademy.Api.Infastructure.Extensions
{
    public static class RuleBuilderExtension
    {
        public static IRuleBuilder<Register, string> Password(this IRuleBuilder<Register, string> ruleBuilder)
        {
            var options = ruleBuilder
                .MinimumLength(8).WithMessage(ErrorMessage.PasswordLength)
                .Matches("[A-Z]").WithMessage(ErrorMessage.PasswordUppercaseLetter)
                .Matches("[a-z]").WithMessage(ErrorMessage.PasswordLovercaseLetter)
                .Matches("[0-9]").WithMessage(ErrorMessage.PasswordDigit);
            return options;
        }
    }
}
