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
public class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeleteTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
    {
        var removeTemplate = _context.Templates.FirstOrDefault(x => x.Id == request.Id);
        if (removeTemplate == null)
        {
            throw new NotFoundException(nameof(Template), request.Id);
        }
        _context.Templates.Remove(removeTemplate);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
