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
public class UserRpointTemplateDto : IMapFrom<UserRpointTemplate>
{
    public string Text { get; set; }
    public DateTime Created { get; set; }
    public Status RequestStatus { get; set; }
    public virtual IList<CommentDto>? Comments { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserRpointTemplateDto, UserRpointTemplate>();
        profile.CreateMap<UserRpointTemplate, UserRpointTemplateDto>();
    }
}
