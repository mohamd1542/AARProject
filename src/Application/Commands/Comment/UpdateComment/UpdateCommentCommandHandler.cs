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
public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public UpdateCommentCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var updateComment = _context.Comments.FirstOrDefault(u => u.Id == request.Id);
        if (updateComment == null)
        {
            throw new NotFoundException(nameof(Comment), request.Id);
        }
        _mapper.Map(request, updateComment);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
