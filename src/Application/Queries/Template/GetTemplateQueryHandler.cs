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
using Microsoft.EntityFrameworkCore;

namespace AARProject.Application.Queries;
public class GetTemplateQueryHandler : IRequestHandler<GetTemplateQuery, GetTemplateQueryVM>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetTemplateQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetTemplateQueryVM> Handle(GetTemplateQuery request, CancellationToken cancellationToken)
    {
        var getTemplate = await _context.Templates
            .Include(x => x.PointTemplates)
            .ThenInclude(x => x.UserRpointTemplates).FirstOrDefaultAsync(x => x.Id == request.Id);
        if (getTemplate == null)
        {
            throw new NotFoundException(nameof(Template), request.Id);
        }
        var getmapTemplate = _mapper.Map<GetTemplateQueryVM>(getTemplate);
        return getmapTemplate;
    }
}
