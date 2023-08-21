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
public class CreateUserRpointTemplateCommandHandler : IRequestHandler<CreateUserRpointTemplateCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public CreateUserRpointTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateUserRpointTemplateCommand request, CancellationToken cancellationToken)
    {
        var UserRpointTemplate = _mapper.Map<UserRpointTemplate>(request);
        _context.UserRpointTemplates.Add(UserRpointTemplate);
        await _context.SaveChangesAsync(cancellationToken);
        return UserRpointTemplate.Id;
    }
}
