using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AARProject.Domain.Entities;
public class Point : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public string PointName { get; set; }
    
    public IList<PointTemplate>? PointTemplates { get; set; } 
    public IList<UserRequestTemplate>? UserRequestTemplates { get; set; }
    public virtual User? User { get; set; }

}
