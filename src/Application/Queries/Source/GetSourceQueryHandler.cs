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
public class GetSourceQueryHandler : IRequestHandler<GetSourceQuery, GetSourceQueryVM>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetSourceQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetSourceQueryVM> Handle(GetSourceQuery request, CancellationToken cancellationToken)
    {
        var getSource = _context.Sources.FirstOrDefault(x => x.Id == request.Id);
        if (getSource == null)
        {
            throw new NotFoundException(nameof(Source), request.Id);
        }
        var getmapSource = _mapper.Map<GetSourceQueryVM>(getSource);
        return getmapSource;
    }
}
