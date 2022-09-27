using System;
using PostSharp.Aspects;
using System.Diagnostics;
using System.Reflection;

namespace Core.Aspects.Postsharp.PerformanceAspects
{
    [Serializable]
    public class PerformanceCounterAspect : OnMethodBoundaryAspect
    {
        private int counter; // sayıcı
        [NonSerialized]
        private Stopwatch stopWatch; // kronometre
        public PerformanceCounterAspect(int counter=0)
        {
            this.counter = counter;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            stopWatch = Activator.CreateInstance<Stopwatch>();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            stopWatch.Start();
            base.OnEntry(args);
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            stopWatch.Stop();
           
            if (stopWatch.Elapsed.TotalSeconds > counter)
            {
                Debug.WriteLine("Performance: {0}.{1} >> {2}", args.Method.DeclaringType.Name, args.Method.Name, stopWatch.Elapsed.TotalSeconds);
          
            }
            stopWatch.Reset();
            base.OnExit(args);
        }
    }
}
