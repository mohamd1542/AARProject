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
public class CreatePointCommandHandler : IRequestHandler<CreatePointCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public CreatePointCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreatePointCommand request, CancellationToken cancellationToken)
    {
        var point = _mapper.Map<Point>(request);
        _context.Points.Add(point);
        await _context.SaveChangesAsync(cancellationToken);
        return point.Id;
    }
}
