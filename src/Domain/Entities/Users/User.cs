using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AARProject.Domain.Entities;
public class User : BaseAuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  
    public IList<Point>? Points { get; set; }
    public IList<Comment>? Comments { get; set; }
    public IList<UserRequestTemplate>? UserRequestTemplates { get; set; } 
    public IList<UserRole>? UserRoles { get; set; } 
}
