using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AARProject.Application.Commands;
public class CreateSourceCommandValidation:AbstractValidator<CreateSourceCommand>
{
    public CreateSourceCommandValidation()
    {
        RuleFor(x => x.SourceName).NotEmpty().NotNull()
                 .WithMessage("Source should not be empty");
    }
}
