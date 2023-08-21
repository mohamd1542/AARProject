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

namespace AARProject.Application.Commands;
public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public UpdateRoleCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var updateRole = _context.Roles.FirstOrDefault(u => u.Id == request.Id);
        if (updateRole == null)
        {
            throw new NotFoundException(nameof(Role), request.Id);
        }
        _mapper.Map(request, updateRole);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
