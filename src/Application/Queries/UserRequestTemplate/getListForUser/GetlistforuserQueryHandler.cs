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
public class GetlistforuserQueryHandler : IRequestHandler<GetlistforuserQuery, List<GetlistforuserQueryVM>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetlistforuserQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<GetlistforuserQueryVM>> Handle(GetlistforuserQuery request, CancellationToken cancellationToken)
    {
        var reslt = _context.UserRequestTemplates
            .Where(x => x.UserId == request.UserId).ToList();
        if (reslt == null)
        {
            throw new NotFoundException(nameof(UserRequestTemplate), request.UserId);
        }
        var listtmplateforuser = _mapper.Map<List<GetlistforuserQueryVM>>(reslt);
        return listtmplateforuser;
    }
}
