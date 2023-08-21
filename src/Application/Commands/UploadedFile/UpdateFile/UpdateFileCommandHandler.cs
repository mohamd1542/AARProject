using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Exceptions;
using AARProject.Application.Common.Interfaces;
using AARProject.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AARProject.Application.Commands;
public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public UpdateFileCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateFileCommand request, CancellationToken cancellationToken)
    {
        var updateFile = _context.Files.FirstOrDefault(u => u.Id == request.Id);
        if (updateFile == null)
        {
            throw new NotFoundException(nameof(UploadedFile), request.Id);
        }
        _mapper.Map(request, updateFile);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
