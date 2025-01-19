using Business.Dtos.UserRole;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.User
{
    public class UserRemoveRoleDtoValidator :AbstractValidator<UserRemoveRoleDto>
    {
        public UserRemoveRoleDtoValidator()
        {
            RuleFor(x => x.UserId)
               .NotEmpty().WithMessage("Cannot be empty userid");

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Cannot be empty roleid");
        }
    }
}
