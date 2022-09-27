using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Log4net
{
    [Serializable]
    public class LoggerService
    {
        private ILog log;

        public LoggerService(ILog log)
        {
            this.log = log;
        }

        public bool IsInfoEnabled => log.IsInfoEnabled;
        public bool IsDebugEnabled => log.IsDebugEnabled;
        public bool IsWarnEnabled => log.IsWarnEnabled;
        public bool IsFatalEnabled => log.IsFatalEnabled;
        public bool IsErrorEnabled => log.IsErrorEnabled;


        public void Info(Object logMessage)
        {
            if (IsInfoEnabled)
            {
                log.Info(logMessage);
            }
        }
        public void Debug(Object logMessage)
        {
            if (IsDebugEnabled)
            {
                log.Debug(logMessage);
            }
        }
        public void Warn(Object logMessage)
        {
            if (IsWarnEnabled)
            {
                log.Warn(logMessage);
            }
        }
        public void Fatal(Object logMessage)
        {
            if (IsFatalEnabled)
            {
                log.Fatal(logMessage);
            }
        }
        public void Error(Object logMessage)
        {
            if (IsErrorEnabled)
            {
                log.Error(logMessage);
            }
        }



    }
}
