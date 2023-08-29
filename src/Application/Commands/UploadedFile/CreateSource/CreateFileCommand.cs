using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Mappings;
using AARProject.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AARProject.Application.Commands;
public class CreateFileCommand:IRequest<Guid>,IMapFrom<UploadedFile>
{
    public Guid UserRequestTemplateId { get; set; }
    public string FileName { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateFileCommand, UploadedFile>();
    }
}
