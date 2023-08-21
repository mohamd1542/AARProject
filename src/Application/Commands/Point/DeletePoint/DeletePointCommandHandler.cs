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
public class DeletePointCommandHandler : IRequestHandler<DeletePointCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeletePointCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeletePointCommand request, CancellationToken cancellationToken)
    {
        var removePoint = _context.Points.FirstOrDefault(x => x.Id == request.Id);
        if (removePoint == null)
        {
            throw new NotFoundException(nameof(Point), request.Id);
        }
        _context.Points.Remove(removePoint);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
