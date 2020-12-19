using System;
using System.Collections.Generic;
using System.Text;

namespace Medusa.Business.Tools
{
    public interface ICustomLog
    {
        void LogError(string message);
    }
}
