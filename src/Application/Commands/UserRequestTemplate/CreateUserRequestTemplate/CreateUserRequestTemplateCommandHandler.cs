using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Interfaces;
using AARProject.Domain.Entities;
using AutoMapper;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AARProject.Application.Commands;
public class CreateUserRequestTemplateCommandHandler : IRequestHandler<CreateUserRequestTemplateCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public CreateUserRequestTemplateCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateUserRequestTemplateCommand request, CancellationToken cancellationToken)
    {
        var pts = _context.PointTemplates.Where(pt => pt.TemplateId == request.TemplateId).ToList();
        PointTemplate mpt = new PointTemplate();
        foreach (var pt in pts)
        {
            if (pt.SeriesNumber == 1)
            {
                mpt = pt;
            }
        }

        var UserRequestTemplate = _mapper.Map<UserRequestTemplate>(request);

        UserRequestTemplate.PointId = mpt.PointId;
        UserRequestTemplate.RequestStatus = Domain.Enums.Status.InProcessing;

        _context.UserRequestTemplates.Add(UserRequestTemplate);
        await _context.SaveChangesAsync(cancellationToken);


        CreateUserRpointTemplateCommand urpt = new CreateUserRpointTemplateCommand();
        urpt.UserRequestTemplateId = UserRequestTemplate.Id;
        urpt.PointTemplateId = mpt.Id;
        urpt.Text = request.Description;
        urpt.Created = DateTime.Now;
        urpt.RequestStatus = Domain.Enums.Status.InProcessing;

        var UserRpointTemplate = _mapper.Map<UserRpointTemplate>(urpt);
        _context.UserRpointTemplates.Add(UserRpointTemplate);
        await _context.SaveChangesAsync(cancellationToken);
        //return UserRpointTemplate.Id;

        return UserRequestTemplate.Id;
    }
}
