using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Commands;
using AARProject.Application.Common.Mappings;
using AARProject.Domain.Entities;
using AutoMapper;

namespace AARProject.Application.Model;
public class CommentDto :IMapFrom<Comment>
{
    public Guid UserId { get; set; }
    public Guid UserRpointTemplateId { get; set; }
    public string Text { get; set; }
    public DateTime CommentDate { get; set; }
    public IList<CommentDto>? InverseCommentNavigation { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CommentDto, Comment>();
        profile.CreateMap<Comment, CommentDto>();
    }
}
