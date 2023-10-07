using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Mappings;
using AARProject.Domain.Entities;
using AARProject.Domain.Enums;
using AutoMapper;

namespace AARProject.Application.Queries;
public class GetlistforuserQueryVM : IMapFrom<UserRequestTemplate>
{
    public string File { get; set; }
    public string Description { get; set; }
    public Status RequestStatus { get; set; }
    public Guid TemplateId { get; set; } 
    public Guid? PointId { get; set; }
    public IList<UploadedFile>? UploadedFiles { get; set; }
    public IList<UserRpointTemplate>? UserRpointTemplates { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserRequestTemplate, GetlistforuserQueryVM>();
    }
}
