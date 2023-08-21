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
public class CreatePointTemplateCommandHandler : IRequestHandler<CreatePointTemplateCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public CreatePointTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreatePointTemplateCommand request, CancellationToken cancellationToken)
    {
        var PointTemplate = _mapper.Map<PointTemplate>(request);
        _context.PointTemplates.Add(PointTemplate);
        await _context.SaveChangesAsync(cancellationToken);
        return PointTemplate.Id;
    }
}
