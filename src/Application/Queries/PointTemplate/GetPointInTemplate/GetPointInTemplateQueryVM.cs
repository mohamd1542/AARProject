using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Mappings;
using AARProject.Application.Model;
using AARProject.Domain.Entities;
using AutoMapper;

namespace AARProject.Application.Queries;
public class GetPointInTemplateQueryVM : IMapFrom<PointTemplate>
{
    public int SeriesNumber { get; set; }
    public string TmplateName { get; set; }
    public string PointName { get; set; }
    public Guid TemplateId { get; set; }
    public Guid PointId { get; set; }
    public IList<UserRpointTemplateDto>? UserRpointTemplates { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PointTemplate, GetPointInTemplateQueryVM>();
    }
}
