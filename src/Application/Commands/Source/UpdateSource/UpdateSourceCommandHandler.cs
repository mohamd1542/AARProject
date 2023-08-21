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
public class UpdateSourceCommandHandler : IRequestHandler<UpdateSourceCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public UpdateSourceCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateSourceCommand request, CancellationToken cancellationToken)
    {
        var updateSource = _context.Sources.FirstOrDefault(u => u.Id == request.Id);
        if (updateSource == null)
        {
            throw new NotFoundException(nameof(Source), request.Id);
        }
        _mapper.Map( request,updateSource);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
