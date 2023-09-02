using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AARProject.Domain.Enums;
public enum Status
{
    [Description("In Processin")]
    InProcessing = 0,
    [Description("Acceptable")]
    Acceptable = 1,
    [Description("UnAcceptable")]
    Unacceptable = 2
}
