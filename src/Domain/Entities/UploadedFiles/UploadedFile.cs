using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AARProject.Domain.Entities;
public class UploadedFile : BaseAuditableEntity
{
    public string FileName { get; set; }
    public Guid UserRequestTemplateId { get; set; }
    public virtual UserRequestTemplate? UserRequestTemplate { get; set; }
}
