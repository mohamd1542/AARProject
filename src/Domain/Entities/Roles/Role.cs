using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AARProject.Domain.Entities;
public class Role : BaseAuditableEntity
{
    public string RoleName { get; set; }

    public IList<RoleSource>? RoleSources { get; set; } 

    public IList<RoleTemplate>? RoleTemplates { get; set; } 

    public IList<UserRole>? UserRoles { get; set; }
}
