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
public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, GetRoleQueryVM>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetRoleQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetRoleQueryVM> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var getRole = _context.Roles.FirstOrDefault(x => x.Id == request.Id);
        if (getRole == null)
        {
            throw new NotFoundException(nameof(Role), request.Id);
        }
        var getmapRole = _mapper.Map<GetRoleQueryVM>(getRole);
        return getmapRole;
    }
}
