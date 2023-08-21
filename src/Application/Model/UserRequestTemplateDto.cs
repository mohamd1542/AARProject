using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Mappings;
using AARProject.Domain.Entities;
using AARProject.Domain.Enums;
using AutoMapper;

namespace AARProject.Application.Model;
public class UserRequestTemplateDto : IMapFrom<UserRequestTemplate>
{
    public string File { get; set; }
    public string Description { get; set; }
    public Status RequestStatus { get; set; }
    public IList<UploadedFileDto>? UploadedFiles { get; set; }
    public IList<UserRpointTemplateDto>? UserRpointTemplates { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserRequestTemplateDto, UserRequestTemplate>();
        profile.CreateMap<UserRequestTemplate, UserRequestTemplateDto>();
    }
}
