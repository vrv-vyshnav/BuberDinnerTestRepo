using BuberDinner.Application.Services.Authentication.Query;
using FluentValidation;

namespace BuberDinner.Application.Authentication.Command.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginQuery>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
