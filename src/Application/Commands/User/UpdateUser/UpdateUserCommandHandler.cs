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
public class UpdatUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public UpdatUserCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var updateUser = _context.Users.FirstOrDefault(u => u.Id == request.Id);
        if (updateUser == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        _mapper.Map(request, updateUser);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
