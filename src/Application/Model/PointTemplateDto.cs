using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Mappings;
using AARProject.Domain.Entities;
using AutoMapper;

namespace AARProject.Application.Model;
public class PointTemplateDto : IMapFrom<PointTemplate>
{
    public int SeriesNumber { get; set; }
    public IList<UserRpointTemplateDto>? UserRpointTemplates { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PointTemplateDto, PointTemplate>();
        profile.CreateMap<PointTemplate, PointTemplateDto>();
    }
}
