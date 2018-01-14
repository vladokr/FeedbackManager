using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Common.Intercases.Loggers
{
    public interface ILogger
    {
        void LogInfo(Object Source, String Message);
        void LogInfo(Object Source, Exception Exception, String Message = null);
        void LogError(Object Source, String Message);
        void LogDebug(Object Source, String Message);
        void LogError(Object Source, Exception Exception, string Message = null);
    }
}
