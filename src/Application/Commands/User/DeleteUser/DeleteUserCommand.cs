using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AARProject.Application.Commands;
public class DeleteUserCommand : IRequest
{
    public Guid Id { get; set; }
}
