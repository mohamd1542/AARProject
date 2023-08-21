using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Commands;
using AARProject.Application.Common.Mappings;
using AARProject.Application.Model;
using AARProject.Domain.Entities;
using AutoMapper;

namespace AARProject.Application.Queries;
public class GetSourceQueryVM:IMapFrom<Source>
{
    public Guid Id { get; set; }
    public string SourceName { get; set; }
    public IList<RoleSource>? RoleSources { get; set; }
    public IList<UserRequestTemplateDto>? UserRequestTemplates { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Source, GetSourceQueryVM>();
    }
}
