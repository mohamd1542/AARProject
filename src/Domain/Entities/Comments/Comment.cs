using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AARProject.Domain.Entities;
public class Comment : BaseAuditableEntity
{
    public string Text { get; set; }
    public DateTime CommentDate { get; set; }
    public Guid UserId { get; set; }
    public Guid UserRpointTemplateId { get; set; }
    public virtual User? User { get; set; }
    public virtual Comment? CommentNavigation { get; set; }
    public virtual UserRpointTemplate? UserRpointTemplate { get; set; }
    public IList<Comment>? InverseCommentNavigation { get; set; } 
}
