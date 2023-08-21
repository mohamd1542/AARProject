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
public class UpdateTemplateCommandHandler : IRequestHandler<UpdateTemplateCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public UpdateTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
    {
        var updateTemplate = _context.Templates.FirstOrDefault(u => u.Id == request.Id);
        if (updateTemplate == null)
        {
            throw new NotFoundException(nameof(Template), request.Id);
        }
        _mapper.Map(request, updateTemplate);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
