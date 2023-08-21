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
public class CreateRoleSourceCommand :IRequest<Guid> ,IMapFrom<UserRole>
{
    public Guid RoleId { get; set; }
    public Guid SourceId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateRoleSourceCommand, RoleSource>();
    }
}
