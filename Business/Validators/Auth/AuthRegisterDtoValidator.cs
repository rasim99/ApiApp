

using Business.Dtos.Auth;
using FluentValidation;

namespace Business.Validators.Auth
{
    public class AuthRegisterDtoValidator : AbstractValidator<AuthRegisterDto>
    {
        public AuthRegisterDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please enter email")
            .EmailAddress().WithMessage("Incorrect email format!");

            RuleFor(x => x.Password.Length)
                .GreaterThanOrEqualTo(8)
                .WithMessage("Password lenght must be minimum 8 character");

            RuleFor(x => x.Password)
                .Equal(x => x.ConfirmPassword)
                .WithMessage("passwords are not equal !");
        }
    }
}
