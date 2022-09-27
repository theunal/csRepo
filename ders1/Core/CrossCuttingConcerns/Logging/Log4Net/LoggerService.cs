using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class LoggerService
    {
        private ILog log;

        public LoggerService(ILog log)
        {
            this.log = log;
        }

        public bool BilgiAktifmi => log.IsInfoEnabled;
        public bool DebugAktifmi => log.IsDebugEnabled;
        public bool WarnAktifmi => log.IsWarnEnabled;
        public bool FatalAktifmi => log.IsFatalEnabled;
        public bool ErrorAktifmi => log.IsErrorEnabled;


        public void Info(Object logMessage)
        {
            if (BilgiAktifmi)
            {
                log.Info(logMessage);
            }
        }
        public void Debug(Object logMessage)
        {
            if (DebugAktifmi)
            {
                log.Debug(logMessage);
            }
        }
        public void Warn(Object logMessage)
        {
            if (WarnAktifmi)
            {
                log.Warn(logMessage);
            }
        }
        public void Fatal(Object logMessage)
        {
            if (FatalAktifmi)
            {
                log.Fatal(logMessage);
            }
        }
        public void Error(Object logMessage)
        {
            if (ErrorAktifmi)
            {
                log.Error(logMessage);
            }
        }



    }
}
