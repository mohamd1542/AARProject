using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace AARProject.Application.Queries;
public class GetListOfTemplatesQueryHandler : IRequestHandler<GetListOfTemplatesQuery, List<GetListOfTemplatesQueryVM>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetListOfTemplatesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetListOfTemplatesQueryVM>> Handle(GetListOfTemplatesQuery request, CancellationToken cancellationToken)
    {
        var listOT = _context.Templates.Where(x => x.PointTemplates.Count>0 ).ToList();

        var reslt =_mapper.Map<List<GetListOfTemplatesQueryVM>>(listOT);

        return reslt;
    }
}
