using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AARProject.Domain.Entities;
public class Template : BaseAuditableEntity
{
    public string TemplateName { get; set; }
    public string Description { get; set; }
    public string CoverImage { get; set; }


    public IList<PointTemplate>? PointTemplates { get; set; } 

    public IList<RoleTemplate>? RoleTemplates { get; set; } 

    public IList<UserRequestTemplate>? UserRequestTemplates { get; set; } 

}
