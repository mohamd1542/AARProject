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
public class UpdatePointCommand : IRequest<Unit>, IMapFrom<Point>
{
    public Guid Id { get; set; }
    public string PointName { get; set; }
    public IList<PointTemplateDto>? PointTemplates { get; set; }
    public IList<UserRequestTemplateDto>? UserRequestTemplates { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdatePointCommand, Point>();
    }
}
