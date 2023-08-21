using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AARProject.Domain.Entities;
public class PointTemplate : BaseAuditableEntity
{
    public int SeriesNumber { get; set; }
    public Guid TemplateId { get; set; }
    public Guid PointId { get; set; }

    public virtual Point? Point { get; set; }
    public virtual Template? Template { get; set; }
    public  IList<UserRpointTemplate>? UserRpointTemplates { get; set; } 

}
