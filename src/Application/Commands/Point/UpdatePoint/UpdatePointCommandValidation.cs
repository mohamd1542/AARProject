using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AARProject.Application.Commands;
public class UpdatePointCommandValidation :AbstractValidator<UpdatePointCommand>
{
    public UpdatePointCommandValidation()
    {
        RuleFor(x => x.PointName).NotEmpty().NotNull()
               .WithMessage("PointName should not be empty");
    }
}
