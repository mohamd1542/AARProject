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
public class GetPointInTemplateQueryHandler : IRequestHandler<GetPointInTemplateQuery, List<GetPointInTemplateQueryVM>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetPointInTemplateQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<GetPointInTemplateQueryVM>> Handle(GetPointInTemplateQuery request, CancellationToken cancellationToken)
    {
        var pointintemplate = from pt in _context.PointTemplates
                    join t in _context.Templates
                    on pt.TemplateId equals t.Id
                    join p in _context.Points
                    on pt.PointId equals p.Id
                    where pt.TemplateId == request.TemplateId
                    select new GetPointInTemplateQueryVM()
                    {
                        TmplateName = t.TemplateName,
                        PointName = p.PointName,
                        SeriesNumber = pt.SeriesNumber,
                        TemplateId = pt.TemplateId,   
                        PointId = pt.PointId,
                    };
        var resalt = pointintemplate.ToList();
        return resalt;
        //var getPointinTemplate = _context.PointTemplates.Where(x => x.TemplateId == request.TemplateId).ToList();

        //if (getPointinTemplate == null)
        //{
        //    throw new NotFoundException(nameof(PointTemplate), request.TemplateId);
        //}

        //var getmapPointinTemplate = _mapper.Map<List<GetPointInTemplateQueryVM>>(getPointinTemplate);

        //return getmapPointinTemplate;
    }
}
