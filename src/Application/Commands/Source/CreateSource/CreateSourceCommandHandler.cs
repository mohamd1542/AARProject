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
public class CreateSourceCommandHandler : IRequestHandler<CreateSourceCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public CreateSourceCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateSourceCommand request, CancellationToken cancellationToken)
    {
        var source = _mapper.Map<Source>(request);
        _context.Sources.Add(source);
        await _context.SaveChangesAsync(cancellationToken);
        return source.Id;
    }
}
