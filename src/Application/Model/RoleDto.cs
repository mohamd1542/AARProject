﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Mappings;
using AARProject.Domain.Entities;
using AutoMapper;

namespace AARProject.Application.Model;
public class RoleDto : IMapFrom<Role>
{
    public string RoleName { get; set; }
    public IList<RoleSource>? RoleSources { get; set; } 
    public IList<RoleTemplate>? RoleTemplates { get; set; } 
    public IList<UserRole>? UserRoles { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RoleDto, Role>();
        profile.CreateMap<Role, RoleDto>();
    }
}
