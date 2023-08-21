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
public class GetUserRpointTemplateQueryHandler : IRequestHandler<GetUserRpointTemplateQuery, GetUserRpointTemplateQueryVM>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetUserRpointTemplateQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetUserRpointTemplateQueryVM> Handle(GetUserRpointTemplateQuery request, CancellationToken cancellationToken)
    {
        var getUserRpointTemplate = _context.UserRpointTemplates.FirstOrDefault(x => x.Id == request.Id);
        if (getUserRpointTemplate == null)
        {
            throw new NotFoundException(nameof(UserRpointTemplate), request.Id);
        }
        var getmapUserRpointTemplate = _mapper.Map<GetUserRpointTemplateQueryVM>(getUserRpointTemplate);
        return getmapUserRpointTemplate;
    }
}
