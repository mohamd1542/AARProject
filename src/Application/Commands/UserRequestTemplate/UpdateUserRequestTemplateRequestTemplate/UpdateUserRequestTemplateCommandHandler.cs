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
public class UpdatUserRequestTemplateCommandHandler : IRequestHandler<UpdateUserRequestTemplateCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public UpdatUserRequestTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateUserRequestTemplateCommand request, CancellationToken cancellationToken)
    {
        var updateUserRequestTemplate = _context.UserRequestTemplates.FirstOrDefault(u => u.Id == request.Id);
        if (updateUserRequestTemplate == null)
        {
            throw new NotFoundException(nameof(UserRequestTemplate), request.Id);
        }
        _mapper.Map(request, updateUserRequestTemplate);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
