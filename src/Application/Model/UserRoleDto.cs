using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Mappings;
using AARProject.Domain.Entities;
using AutoMapper;

namespace AARProject.Application.Model;
public class UserRoleDto : IMapFrom<UserRole>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserRoleDto, UserRole>();
        profile.CreateMap<UserRole, UserRoleDto>();
    }
}
