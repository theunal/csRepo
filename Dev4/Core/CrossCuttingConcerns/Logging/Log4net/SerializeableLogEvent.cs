using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Log4net
{
    [Serializable]
    public class SeralizableLogEvent
    {
        private LoggingEvent loggingEvent;
        public SeralizableLogEvent(LoggingEvent loggingEvent)
        {
            this.loggingEvent = loggingEvent;
        }

        public string UserName => loggingEvent.UserName;
        public object MessageObject => loggingEvent.MessageObject;

    }
}
