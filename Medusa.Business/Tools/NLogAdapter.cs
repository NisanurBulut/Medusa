using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medusa.Business.Tools
{
    public class NLogAdapter : ICustomLog
    {
        public void LogError(string message)
        {
            var logger = LogManager.GetLogger("fileLogger");
            logger.Log(LogLevel.Error, message);
        }
    }
}
