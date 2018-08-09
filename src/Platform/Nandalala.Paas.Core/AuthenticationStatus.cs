using System;
using System.Collections.Generic;
using System.Text;

namespace Nandalala.Paas.Core
{
    [Flags]
    public enum AuthenticationStatus
    {
        None = 0,
        Success = 1,
        Failure = 2,
        Locked = 4,
        Disabled = 5
    }
}
