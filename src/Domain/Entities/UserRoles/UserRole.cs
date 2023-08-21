using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AARProject.Domain.Entities;
public class UserRole:BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public virtual Role? Role { get; set; }
    public virtual User? User { get; set; }
}
