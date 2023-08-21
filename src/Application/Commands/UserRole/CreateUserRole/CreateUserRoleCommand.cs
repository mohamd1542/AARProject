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
public class CreateUserRoleCommand : IRequest<Guid>, IMapFrom<UserRole>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUserRoleCommand, UserRole>();
    }
}
