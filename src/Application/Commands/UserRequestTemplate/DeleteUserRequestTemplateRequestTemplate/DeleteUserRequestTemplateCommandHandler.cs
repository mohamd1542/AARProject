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
public class DeleteUserRequestTemplateCommandHandler : IRequestHandler<DeleteUserRequestTemplateCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeleteUserRequestTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeleteUserRequestTemplateCommand request, CancellationToken cancellationToken)
    {
        var removeUserRequestTemplate = _context.UserRequestTemplates.FirstOrDefault(x => x.Id == request.Id);
        if (removeUserRequestTemplate == null)
        {
            throw new NotFoundException(nameof(UserRequestTemplate), request.Id);
        }
        _context.UserRequestTemplates.Remove(removeUserRequestTemplate);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
