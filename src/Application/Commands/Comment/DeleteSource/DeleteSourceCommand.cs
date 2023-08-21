using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AARProject.Application.Commands;
public class DeleteCommentCommand:IRequest
{
    public Guid Id { get; set; }
}
