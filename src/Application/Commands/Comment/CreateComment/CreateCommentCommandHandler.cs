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
public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public CreateCommentCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var Comment = _mapper.Map<Comment>(request);
        _context.Comments.Add(Comment);
        await _context.SaveChangesAsync(cancellationToken);
        return Comment.Id;
    }
}
