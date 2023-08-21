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
public class UpdatPointTemplateCommandHandler : IRequestHandler<UpdatePointTemplateCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public UpdatPointTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdatePointTemplateCommand request, CancellationToken cancellationToken)
    {
        var updatePointTemplate = _context.PointTemplates.FirstOrDefault(u => u.Id == request.Id);
        if (updatePointTemplate == null)
        {
            throw new NotFoundException(nameof(PointTemplate), request.Id);
        }
        _mapper.Map(request, updatePointTemplate);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
