using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AARProject.Application.Commands;
public class UpdateRoleCommandValidation: AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidation()
    {
        RuleFor(x => x.RoleName).NotEmpty().NotNull()
                .WithMessage("Role should not be empty");
    }
}
