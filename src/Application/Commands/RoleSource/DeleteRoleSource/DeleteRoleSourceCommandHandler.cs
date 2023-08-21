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
public class DeleteRoleSourceCommandHandler : IRequestHandler<DeleteRoleSourceCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeleteRoleSourceCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeleteRoleSourceCommand request, CancellationToken cancellationToken)
    {
        var removerolesource = _context.RoleSources.FirstOrDefault(x => x.Id == request.Id);
        if (removerolesource == null)
        {
            throw new NotFoundException(nameof(RoleSource), request.Id);
        }
        _context.RoleSources.Remove(removerolesource);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
