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
public class CreatePointTemplateCommand : IRequest<Guid>, IMapFrom<PointTemplate>
{
    public Guid TemplateId { get; set; }
    public Guid PointId { get; set; }
    public int SeriesNumber { get; set; }
    public IList<UserRpointTemplateDto>? UserRpointTemplates { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePointTemplateCommand, PointTemplate>();
    }
}
