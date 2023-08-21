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
public class GetPointQueryHandler : IRequestHandler<GetPointQuery, GetPointQueryVM>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetPointQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetPointQueryVM> Handle(GetPointQuery request, CancellationToken cancellationToken)
    {
        var getPoint = _context.Points.FirstOrDefault(x => x.Id == request.Id);
        if (getPoint == null)
        {
            throw new NotFoundException(nameof(Point), request.Id);
        }
        var getmapPoint = _mapper.Map<GetPointQueryVM>(getPoint);
        return getmapPoint;
    }
}
