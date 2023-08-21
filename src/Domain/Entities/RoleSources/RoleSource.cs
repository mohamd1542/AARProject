using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AARProject.Domain.Entities;
public class RoleSource : BaseAuditableEntity
{
    public Guid RoleId { get; set; }
    public Guid SourceId { get; set; }

    public virtual Role? Role { get; set; }
    public virtual Source? Source { get; set; }
}
