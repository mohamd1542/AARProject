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
public class CreateUserCommand : IRequest<Guid>, IMapFrom<User>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IList<CommentDto>? Comments { get; set; }
    public IList<UserRequestTemplateDto>? UserRequestTemplates { get; set; }
    public IList<UserRoleDto>? UserRoles { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUserCommand, User>();
    }
}
