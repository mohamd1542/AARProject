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
public class CreateUserRequestTemplateCommandHandler : IRequestHandler<CreateUserRequestTemplateCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public CreateUserRequestTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateUserRequestTemplateCommand request, CancellationToken cancellationToken)
    {
        var UserRequestTemplate = _mapper.Map<UserRequestTemplate>(request);
        _context.UserRequestTemplates.Add(UserRequestTemplate);
        await _context.SaveChangesAsync(cancellationToken);
        return UserRequestTemplate.Id;
    }
}
