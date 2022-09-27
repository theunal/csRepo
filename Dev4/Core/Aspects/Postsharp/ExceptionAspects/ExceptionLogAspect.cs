using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4net;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Postsharp.ExceptionAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class ExceptionLogAspect : OnExceptionAspect
    {
        private LoggerService loggerService;
        private readonly Type loggerType;

        public ExceptionLogAspect(Type loggerType)
        {
            this.loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("wrong logger type");
            }

            loggerService = (LoggerService)Activator.CreateInstance(loggerType);

            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            if (loggerService != null)
            {
                loggerService.Error(args.Exception);
            }
        }
    }
}
