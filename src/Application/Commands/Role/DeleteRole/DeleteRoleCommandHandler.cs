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
public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeleteRoleCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var removeRole = _context.Roles.FirstOrDefault(x => x.Id == request.Id);
        if (removeRole == null)
        {
            throw new NotFoundException(nameof(Role), request.Id);
        }
        _context.Roles.Remove(removeRole);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
