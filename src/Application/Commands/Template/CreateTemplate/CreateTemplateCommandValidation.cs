using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AARProject.Application.Commands;
public class CreateTemplateCommandValidation : AbstractValidator<CreateTemplateCommand>
{
    public CreateTemplateCommandValidation()
    {
        RuleFor(x => x.TemplateName).NotEmpty().NotNull()
         .WithMessage("Name should not be empty");

        RuleFor(x => x.Description).NotEmpty().NotNull()
         .WithMessage("Description should not be empty");

        RuleFor(x => x.CoverImage).NotEmpty().NotNull()
         .WithMessage("CoverImage should not be empty");
    }
}
