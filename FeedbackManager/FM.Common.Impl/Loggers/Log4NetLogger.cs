using FM.Common.Intercases.Loggers;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Common.Impl.Loggers
{
    public class Log4NetLogger : ILogger
    {
        ILog logger = null;

        public Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public void LogDebug(Object Source, string Message)
        {
            logger = log4net.LogManager.GetLogger(Source?.GetType());
            if (logger.IsDebugEnabled)
            {
                logger.Debug(Message);
            }
        }

        public void LogError(Object Source, string Message)
        {
            logger = log4net.LogManager.GetLogger(Source?.GetType());
            if (logger.IsErrorEnabled)
            {
                logger.Error(Message);
            }
        }

        public void LogError(Object Source, Exception Exception, string Message = null)
        {
            logger = log4net.LogManager.GetLogger(Source?.GetType());
            if (logger.IsErrorEnabled)
            {
                String detailedMessage = CreateDetailedMessage(Exception, Message);
                logger.Error(detailedMessage);
            }
        }

        public void LogInfo(Object Source, string Message)
        {
            logger = log4net.LogManager.GetLogger(Source?.GetType());
            if (logger.IsInfoEnabled)
            {
                logger.Info(Message);
            }
        }

        public void LogInfo(object Source, Exception Exception, string Message = null)
        {
            logger = log4net.LogManager.GetLogger(Source?.GetType());
            if (logger.IsInfoEnabled)
            {
                String detailedMessage = CreateDetailedMessage(Exception, Message);
                logger.Info(detailedMessage);
            }
        }

        private String CreateDetailedMessage(Exception ex, String Message)
        {
            if (ex == null) return Message;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Message);
            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.StackTrace);
            if(ex.InnerException != null)
            {
                sb.AppendLine(ex.InnerException.Message);
                sb.AppendLine(ex.InnerException.StackTrace);
            }

            return sb.ToString();
        }
    }
}
