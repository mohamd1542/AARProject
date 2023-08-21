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
public class DeletePointTemplateCommandHandler : IRequestHandler<DeletePointTemplateCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeletePointTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeletePointTemplateCommand request, CancellationToken cancellationToken)
    {
        var removePointTemplate = _context.PointTemplates.FirstOrDefault(x => x.Id == request.Id);
        if (removePointTemplate == null)
        {
            throw new NotFoundException(nameof(PointTemplate), request.Id);
        }
        _context.PointTemplates.Remove(removePointTemplate);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
