using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AARProject.Domain.Entities;
public class UserRpointTemplate : BaseAuditableEntity
{
    public string Text { get; set; }
    public DateTime Created { get; set; }
    public Guid UserRequestTemplateId { get; set; }
    public Guid PointTemplateId { get; set; }
    public Status RequestStatus { get; set; }

    public virtual PointTemplate? PointTemplate { get; set; }
    public virtual UserRequestTemplate? UserRequestTemplate { get; set; }
    public virtual IList<Comment>? Comments { get; set; } 
}
