using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Common.Intercases.Loggers
{
    public interface ILogger
    {
        void LogInfo(String Message);
        void LogError(String Message);
        void LogDebug(String Message);
        void LogException(Exception Exception, String Message=null);
    }
}
