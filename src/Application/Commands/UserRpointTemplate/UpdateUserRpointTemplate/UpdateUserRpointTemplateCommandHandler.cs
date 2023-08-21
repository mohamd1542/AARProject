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
public class UpdatUserRpointTemplateCommandHandler : IRequestHandler<UpdateUserRpointTemplateCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public UpdatUserRpointTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateUserRpointTemplateCommand request, CancellationToken cancellationToken)
    {
        var updateUserRpointTemplate = _context.UserRpointTemplates.FirstOrDefault(u => u.Id == request.Id);
        if (updateUserRpointTemplate == null)
        {
            throw new NotFoundException(nameof(UserRpointTemplate), request.Id);
        }
        _mapper.Map(request, updateUserRpointTemplate);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
