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
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeleteUserCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var removeUser = _context.Users.FirstOrDefault(x => x.Id == request.Id);
        if (removeUser == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        _context.Users.Remove(removeUser);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
