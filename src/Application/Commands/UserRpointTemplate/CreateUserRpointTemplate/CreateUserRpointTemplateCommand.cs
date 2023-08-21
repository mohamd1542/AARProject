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
using MediatR;

namespace AARProject.Application.Commands;
public class CreateUserRpointTemplateCommand : IRequest<Guid>, IMapFrom<UserRpointTemplate>
{
    public Guid UserRequestTemplateId { get; set; }
    public Guid PointTemplateId { get; set; }
    public string Text { get; set; }
    public DateTime Created { get; set; }
    public Status RequestStatus { get; set; }
    public virtual IList<CommentDto>? Comments { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUserRpointTemplateCommand, UserRpointTemplate>();
    }
}
