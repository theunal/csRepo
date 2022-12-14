using Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheAspect : MethodInterceptionAspect
    {
        private Type cacheType;
        private int cacheTime;
        private ICacheManager cacheManager;
        public CacheAspect(Type cacheType, int cacheTime=60)
        {
            this.cacheType = cacheType;
            this.cacheTime = cacheTime;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(cacheType) == false)
            {
                throw new Exception("wrong cache type");
            }
            cacheManager = (ICacheManager)Activator.CreateInstance(cacheType);
            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format("{0}.{1}.{2}",
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name,
                args.Method.Name);

            var arguments = args.Arguments.ToList();

            var key = string.Format("{0}({1})", methodName,
                string.Join(",", arguments.Select(p => p != null ? p.ToString() : "<Null>")));


            if (cacheManager.IsAdd(key))
            {
                args.ReturnValue = cacheManager.Get<object>(key);
            }

            cacheManager.Add(key, args.ReturnValue, cacheTime);
            base.OnInvoke(args);
        }



        
    }
}
