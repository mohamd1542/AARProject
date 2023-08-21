using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AARProject.Domain.Entities;
public class RoleTemplate : BaseAuditableEntity
{
    public Guid RoleId { get; set; }
    public Guid TemplateId { get; set; }

    public Role? Role { get; set; }
    public Template? Template { get; set; }


}
