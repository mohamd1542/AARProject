using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Interfaces;
using AARProject.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AARProject.Application.Commands;
public class CreateRoleTemplateCommandHandler : IRequestHandler<CreateRoleTemplateCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public CreateRoleTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateRoleTemplateCommand request, CancellationToken cancellationToken)
    {
        var roletemplate = _mapper.Map<RoleTemplate>(request);
        _context.RoleTemplates.Add(roletemplate);
        await _context.SaveChangesAsync(cancellationToken);
        return roletemplate.Id;
    }
}
