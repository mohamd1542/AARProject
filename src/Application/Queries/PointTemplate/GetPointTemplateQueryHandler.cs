using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Exceptions;
using AARProject.Application.Common.Interfaces;
using AARProject.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AARProject.Application.Queries;
public class GetPointTemplateQueryHandler : IRequestHandler<GetPointTemplateQuery, GetPointTemplateQueryVM>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetPointTemplateQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetPointTemplateQueryVM> Handle(GetPointTemplateQuery request, CancellationToken cancellationToken)
    {
        var getPointTemplate = _context.PointTemplates.FirstOrDefault(x => x.Id == request.Id);
        if (getPointTemplate == null)
        {
            throw new NotFoundException(nameof(PointTemplate), request.Id);
        }
        var getmapPointTemplate = _mapper.Map<GetPointTemplateQueryVM>(getPointTemplate);
        return getmapPointTemplate;
    }
}
