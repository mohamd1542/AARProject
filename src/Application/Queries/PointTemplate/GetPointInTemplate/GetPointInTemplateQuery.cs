using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AARProject.Application.Queries;
public class GetPointInTemplateQuery :IRequest<List<GetPointInTemplateQueryVM>>
{
    public Guid TemplateId { get; set; }
}
