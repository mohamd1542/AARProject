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

namespace AARProject.Application.Queries;
public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryVM>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetUserQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetUserQueryVM> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var getUser = _context.Users.FirstOrDefault(x => x.Id == request.Id);
        if (getUser == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        var getmapUser = _mapper.Map<GetUserQueryVM>(getUser);
        return getmapUser;
    }
}
