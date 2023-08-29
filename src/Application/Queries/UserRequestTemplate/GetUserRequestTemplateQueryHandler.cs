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
public class GetUserRequestTemplateQueryHandler : IRequestHandler<GetUserRequestTemplateQuery, GetUserRequestTemplateQueryVM>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetUserRequestTemplateQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetUserRequestTemplateQueryVM> Handle(GetUserRequestTemplateQuery request, CancellationToken cancellationToken)
    {
        var getUserRequestTemplate = await _context.UserRequestTemplates
            .Include(x => x.UserRpointTemplates)
            .Include(x => x.UploadedFiles)
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (getUserRequestTemplate == null)
        {
            throw new NotFoundException(nameof(UserRequestTemplate), request.Id);
        }
        var getmapUserRequestTemplate = _mapper.Map<GetUserRequestTemplateQueryVM>(getUserRequestTemplate);
        return getmapUserRequestTemplate;
    }
}
