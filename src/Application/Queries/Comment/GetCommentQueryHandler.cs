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
using Microsoft.EntityFrameworkCore;

namespace AARProject.Application.Queries;
public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, GetCommentQueryVM>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetCommentQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetCommentQueryVM> Handle(GetCommentQuery request, CancellationToken cancellationToken)
    {
        var getComment = _context.Comments.Include(x => x.InverseCommentNavigation).FirstOrDefault(x => x.Id == request.Id);
        if (getComment == null)
        {
            throw new NotFoundException(nameof(Comment), request.Id);
        }
        var getmapComment = _mapper.Map<GetCommentQueryVM>(getComment);
        return getmapComment;
    }
}
