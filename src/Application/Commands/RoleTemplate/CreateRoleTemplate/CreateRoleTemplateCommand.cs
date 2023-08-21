using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Mappings;
using AARProject.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AARProject.Application.Commands;
public class CreateRoleTemplateCommand : IRequest<Guid>, IMapFrom<RoleTemplate>
{
    public Guid RoleId { get; set; }
    public Guid TemplateId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateRoleTemplateCommand, RoleTemplate>();
    }
}
