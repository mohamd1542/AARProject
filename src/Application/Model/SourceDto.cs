using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Mappings;
using AARProject.Domain.Entities;
using AutoMapper;

namespace AARProject.Application.Model;
public class SourceDto : IMapFrom<Source>
{
    public string SourceName { get; set; }
    public IList<RoleSource>? RoleSources { get; set; } 
    public IList<UserRequestTemplateDto>? UserRequestTemplates { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<SourceDto, Source>();
        profile.CreateMap<Source, SourceDto>();
    }
}
