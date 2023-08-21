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
public class CreateCommentCommand : IRequest<Guid>, IMapFrom<Comment>
{
    public Guid UserId { get; set; }
    public Guid UserRpointTemplateId { get; set; }
    public string Text { get; set; }
    public DateTime CommentDate { get; set; }
    public IList<CommentDto>? InverseCommentNavigation { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCommentCommand, Comment>();
    }
}
