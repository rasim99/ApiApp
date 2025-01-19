using Business.Dtos;
using Business.Dtos.UserRole;
using FluentValidation;

namespace Business.Validators.User
{
    public class UserAddToRoleDtoValidator :AbstractValidator<UserAddToRoleDto>
    {
        public UserAddToRoleDtoValidator()
        {
            RuleFor(x=>x.UserId)
                .NotEmpty().WithMessage("Cannot be empty userid");

            RuleFor(x=>x.RoleId)
                .NotEmpty().WithMessage("Cannot be empty roleid");
        }
    }
}
