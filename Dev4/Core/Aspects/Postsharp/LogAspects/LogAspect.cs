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

namespace Core.Aspects.Postsharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method,TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect : OnMethodBoundaryAspect
    {
        private LoggerService loggerService;
        private readonly Type loggerType;

        public LogAspect(Type loggerType)
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

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!loggerService.IsErrorEnabled)
            {
                return;
            }
            try
            {
                var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)

                }).ToList();

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ?
                    null :
                    args.Method.DeclaringType.Name,

                    MethodName = args.Method.Name,
                    Parameters = logParameters

                };

                loggerService.Info(logDetail);
            }
            catch { }
            
        }
    }
}
