using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Mappings;
using AARProject.Domain.Entities;
using AutoMapper;

namespace AARProject.Application.Model;
public class PointDto : IMapFrom<Point>
{

    public string PointName { get; set; }
    public IList<PointTemplateDto>? PointTemplates { get; set; } 
    public IList<UserRequestTemplateDto>? UserRequestTemplates { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PointDto, Point>();
        profile.CreateMap<Point, PointDto>();
    }
}
