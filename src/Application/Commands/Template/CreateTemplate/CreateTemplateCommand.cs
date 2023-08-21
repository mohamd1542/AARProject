using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Mappings;
using AARProject.Application.Model;
using AARProject.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AARProject.Application.Commands;
public class CreateTemplateCommand : IRequest<Guid>, IMapFrom<Template>
{
    public string TemplateName { get; set; }
    public string Description { get; set; }
    public string CoverImage { get; set; }
    public IList<PointTemplateDto>? PointTemplates { get; set; }
    public IList<RoleTemplate>? RoleTemplates { get; set; }
    public IList<UserRequestTemplateDto>? UserRequestTemplates { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateTemplateCommand, Template>();
    }
}
