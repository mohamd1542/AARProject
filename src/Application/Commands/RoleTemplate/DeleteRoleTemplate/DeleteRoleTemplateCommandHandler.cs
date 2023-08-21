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
public class DeleteRoleTemplateCommandHandler : IRequestHandler<DeleteRoleTemplateCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeleteRoleTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeleteRoleTemplateCommand request, CancellationToken cancellationToken)
    {
        var removeroletemplate = _context.RoleTemplates.FirstOrDefault(x => x.Id == request.Id);
        if (removeroletemplate == null)
        {
            throw new NotFoundException(nameof(RoleTemplate), request.Id);
        }
        _context.RoleTemplates.Remove(removeroletemplate);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
