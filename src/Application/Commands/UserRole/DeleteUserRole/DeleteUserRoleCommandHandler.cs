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
public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeleteUserRoleCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        var removeuserrole = _context.UserRoles.FirstOrDefault(x => x.Id == request.Id);
        if (removeuserrole == null)
        {
            throw new NotFoundException(nameof(UserRole), request.Id);
        }
        _context.UserRoles.Remove(removeuserrole);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
