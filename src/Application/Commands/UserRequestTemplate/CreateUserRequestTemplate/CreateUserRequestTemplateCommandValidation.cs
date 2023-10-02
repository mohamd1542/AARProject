using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AARProject.Application.Commands;
public class CreateUserRequestTemplateCommandValidation :AbstractValidator<CreateUserRequestTemplateCommand>
{
    public CreateUserRequestTemplateCommandValidation()
    {
        RuleFor(x => x.Description)
          .NotEmpty().WithMessage("Description is required.")
          .MinimumLength(10).WithMessage("Description must be at least 10 characters.")
          .MaximumLength(500).WithMessage("Description can't be longer than 500 characters.");
    }
}
