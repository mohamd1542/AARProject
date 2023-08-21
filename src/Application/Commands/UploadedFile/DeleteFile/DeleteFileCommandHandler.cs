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
using Microsoft.EntityFrameworkCore;

namespace AARProject.Application.Commands;
public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public DeleteFileCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        var removeFile = _context.Files.FirstOrDefault(x => x.Id == request.Id);
        if (removeFile == null)
        {
            throw new NotFoundException(nameof(File), request.Id);
        }
        _context.Files.Remove(removeFile);
        await _context.SaveChangesAsync(cancellationToken);

        //var entity = await _context.Files
        //  .Where(l => l.Id == request.Id)
        //  .FirstOrDefaultAsync(cancellationToken);

        //if (entity == null)
        //{
        //    throw new NotFoundException(nameof(UploadedFile), request.Id);
        //}

        //_context.Files.Remove(entity);

        //await _context.SaveChangesAsync(cancellationToken);

    }
}
