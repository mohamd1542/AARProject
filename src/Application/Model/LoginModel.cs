using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AARProject.Application.Model;
public class LoginModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string AccessToken { get; set; }=string.Empty;
    public string RefresToken { get; set; } = string.Empty;
}
