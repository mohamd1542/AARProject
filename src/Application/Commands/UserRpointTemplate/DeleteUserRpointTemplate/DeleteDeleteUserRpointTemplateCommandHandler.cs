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
public class DeleteUserRpointTemplateCommandHandler : IRequestHandler<DeleteUserRpointTemplateCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeleteUserRpointTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeleteUserRpointTemplateCommand request, CancellationToken cancellationToken)
    {
        var removeUserRpointTemplate = _context.UserRpointTemplates.FirstOrDefault(x => x.Id == request.Id);
        if (removeUserRpointTemplate == null)
        {
            throw new NotFoundException(nameof(UserRpointTemplate), request.Id);
        }
        _context.UserRpointTemplates.Remove(removeUserRpointTemplate);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
