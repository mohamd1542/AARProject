using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AARProject.Application.Commands;
public class CreateRoleCommandValidation : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidation()
    {
        RuleFor(x => x.RoleName).NotEmpty().NotNull()
               .WithMessage("Role should not be empty");
    }
}
