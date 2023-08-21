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
public class CreatePointCommand : IRequest<Guid>, IMapFrom<Point>
{
    public Guid UserId { get; set; }
    public string PointName { get; set; }
    public IList<PointTemplateDto>? PointTemplates { get; set; }
    public IList<UserRequestTemplateDto>? UserRequestTemplates { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePointCommand, Point>();
    }
}
