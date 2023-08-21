using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AARProject.Application.Commands;
public class CreatePointTemplateCommandValidation:AbstractValidator<CreatePointTemplateCommand>
{
    public CreatePointTemplateCommandValidation()
    {
        RuleFor(x => x.SeriesNumber)
            .NotEmpty().WithMessage("Number is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Number should be positive.");
    }
}
