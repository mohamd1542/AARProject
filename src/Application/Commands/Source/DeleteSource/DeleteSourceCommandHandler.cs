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
public class DeleteSourceCommandHandler : IRequestHandler<DeleteSourceCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeleteSourceCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeleteSourceCommand request, CancellationToken cancellationToken)
    {
        var removeSource = _context.Sources.FirstOrDefault(x => x.Id == request.Id);
        if (removeSource == null)
        {
            throw new NotFoundException(nameof(Source), request.Id);
        }
        _context.Sources.Remove(removeSource);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
