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
public class GetUserRequestTemplateQueryVM : IMapFrom<UserRequestTemplate>
{
    public Guid Id { get; set; }
    public string File { get; set; }
    public string Description { get; set; }
    public Status RequestStatus { get; set; }
    public IList<UploadedFileDto>? UploadedFiles { get; set; }
    public IList<UserRpointTemplateDto>? UserRpointTemplates { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserRequestTemplate, GetUserRequestTemplateQueryVM>();
    }
}
