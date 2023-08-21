using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AARProject.Domain.Entities;
public class Source:BaseAuditableEntity
{
    public string SourceName { get; set; }

    public IList<RoleSource>? RoleSources { get; set; } 

    public IList<UserRequestTemplate>? UserRequestTemplates { get; set; } 
}
