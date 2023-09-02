using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Model;
using MediatR;

namespace AARProject.Application.Commands;
public class CreateRefreshTokenItem:IRequest<AuthenticatedResponse>
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}
