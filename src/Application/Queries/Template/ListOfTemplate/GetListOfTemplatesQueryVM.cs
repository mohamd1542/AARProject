using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Mappings;
using AARProject.Application.Model;
using AARProject.Domain.Entities;
using AARProject.Domain.Enums;
using AutoMapper;

namespace AARProject.Application.Queries;
public class GetListOfTemplatesQueryVM : IMapFrom<Template>
{
    public string TemplateName { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Template, GetListOfTemplatesQueryVM>();
    }
}
