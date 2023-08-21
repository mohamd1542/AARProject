using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AARProject.Application.Queries;
public class GetUserRequestTemplateQuery : IRequest<GetUserRequestTemplateQueryVM>
{
    public Guid Id { get; set; }
}
