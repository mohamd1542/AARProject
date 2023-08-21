using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AARProject.Application.Queries;
public class GetPointTemplateQuery : IRequest<GetPointTemplateQueryVM>
{
    public Guid Id { get; set; }
}
