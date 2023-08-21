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
public class GetTemplateQueryVM : IMapFrom<Template>
{
    public Guid Id { get; set; }
    public string TemplateName { get; set; }
    public string Description { get; set; }
    public string CoverImage { get; set; }
    public IList<PointTemplateDto>? PointTemplates { get; set; }
    public IList<RoleTemplate>? RoleTemplates { get; set; }
    public IList<UserRequestTemplateDto>? UserRequestTemplates { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Template, GetTemplateQueryVM>();
    }
}
