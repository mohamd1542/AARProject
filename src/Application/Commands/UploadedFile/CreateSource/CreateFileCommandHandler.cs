using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Interfaces;
using AARProject.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AARProject.Application.Commands;
public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public CreateFileCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        var file = _mapper.Map<UploadedFile>(request);
        _context.Files.Add(file);
        await _context.SaveChangesAsync(cancellationToken);
        return file.Id;
    }
}
