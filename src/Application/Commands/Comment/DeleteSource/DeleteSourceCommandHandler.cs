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
public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeleteCommentCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var removeComment = _context.Comments.FirstOrDefault(x => x.Id == request.Id);
        if (removeComment == null)
        {
            throw new NotFoundException(nameof(Comment), request.Id);
        }
        _context.Comments.Remove(removeComment);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
