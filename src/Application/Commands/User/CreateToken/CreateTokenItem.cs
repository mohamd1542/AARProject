using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Model;
using MediatR;

namespace AARProject.Application.Commands;
public class CreateTokenItem : IRequest<LoginModel>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
