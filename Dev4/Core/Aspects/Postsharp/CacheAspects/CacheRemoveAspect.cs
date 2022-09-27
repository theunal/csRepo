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
    public class CacheRemoveAspect : OnMethodBoundaryAspect
    {
        private string pattern;
        private Type cacheType;
        private ICacheManager cacheManager;

        public CacheRemoveAspect(Type cacheType)
        {
            this.cacheType = cacheType;
        }
        public CacheRemoveAspect(string pattern,Type cacheType)
        {
            this.pattern = pattern;
            this.cacheType = cacheType;
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

        public override void OnSuccess(MethodExecutionArgs args)
        {
            cacheManager.RemoveByPattern(string.IsNullOrEmpty(pattern) ?
                string.Format("{0}.{1}.*",
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name) :
                pattern);
        }
    }
}
