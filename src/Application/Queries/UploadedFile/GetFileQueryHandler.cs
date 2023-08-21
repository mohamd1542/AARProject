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
public class GetFileQueryHandler : IRequestHandler<GetFileQuery, GetFileQueryVM>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetFileQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetFileQueryVM> Handle(GetFileQuery request, CancellationToken cancellationToken)
    {
        var getFile = _context.Files.FirstOrDefault(x => x.Id == request.Id);
        if (getFile == null)
        {
            throw new NotFoundException(nameof(File), request.Id);
        }
        var getmapFile = _mapper.Map<GetFileQueryVM>(getFile);
        return getmapFile;
    }
}
