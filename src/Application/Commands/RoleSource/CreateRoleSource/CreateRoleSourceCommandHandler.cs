using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Interfaces;
using AARProject.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AARProject.Application.Commands;
public class CreateRoleSourceCommandHandler : IRequestHandler<CreateRoleSourceCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public CreateRoleSourceCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateRoleSourceCommand request, CancellationToken cancellationToken)
    {
        var rolesource = _mapper.Map<RoleSource>(request);
        _context.RoleSources.Add(rolesource);
        await _context.SaveChangesAsync(cancellationToken);
        return rolesource.Id;
    }
}
