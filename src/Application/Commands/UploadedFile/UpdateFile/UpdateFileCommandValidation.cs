using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AARProject.Application.Commands;
public class UpdateFileCommandValidation:AbstractValidator<UpdateFileCommand>
{
    public UpdateFileCommandValidation()
    {
        RuleFor(x => x.FileName).NotEmpty().NotNull()
            .WithMessage("File should not be empty");
    }
}
