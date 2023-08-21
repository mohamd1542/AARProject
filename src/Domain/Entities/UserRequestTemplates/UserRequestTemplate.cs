using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AARProject.Domain.Entities;
public class UserRequestTemplate : BaseAuditableEntity
{
    public string File { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public Guid TemplateId { get; set; }
    public Guid PointId { get; set; }
    public Guid SourceId { get; set; }
    public Status RequestStatus { get; set; }

    public virtual User? User { get; set; }
    public virtual Template? Template { get; set; }
    public virtual Point? Point { get; set; }
    public virtual Source? Source { get; set; }

    public IList<UploadedFile>? UploadedFiles { get; set; } 

    public IList<UserRpointTemplate>? UserRpointTemplates { get; set; } 

}
