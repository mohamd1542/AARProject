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
public class UpdatePointCommandHandler : IRequestHandler<UpdatePointCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public UpdatePointCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdatePointCommand request, CancellationToken cancellationToken)
    {
        var updatePoint = _context.Points.FirstOrDefault(u => u.Id == request.Id);
        if (updatePoint == null)
        {
            throw new NotFoundException(nameof(Point), request.Id);
        }
        _mapper.Map(request, updatePoint);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
