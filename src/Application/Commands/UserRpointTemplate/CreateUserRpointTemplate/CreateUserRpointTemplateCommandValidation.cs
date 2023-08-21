using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AARProject.Application.Commands;
public class CreateUserRpointTemplateCommandValidation:AbstractValidator<CreateUserRpointTemplateCommand>
{
    public CreateUserRpointTemplateCommandValidation()
    {
        RuleFor(x => x.Text).NotEmpty().NotNull()
           .WithMessage("Text should not be empty");

        RuleFor(x => x.Created).NotEmpty()
               .LessThanOrEqualTo(DateTime.Now).WithMessage("CommentDate should not be in the future.")
               .GreaterThan(new DateTime(2022, 1, 1)).WithMessage("CommentDate should be after January 1, 2022.");
    }
}
