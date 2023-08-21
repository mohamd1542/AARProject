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
public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public CreateUserRoleCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var userrole = _mapper.Map<UserRole>(request);
        _context.UserRoles.Add(userrole);
        await _context.SaveChangesAsync(cancellationToken);
        return userrole.Id;
    }
}
