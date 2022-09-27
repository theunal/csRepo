using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache => MemoryCache.Default;




        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }
        public void Add(string key, object data, int cacheTime=60)
        {
            if (data == null)
            {
                return;
            }

            var policy = new CacheItemPolicy
            {   // eger data boş değilse verilen cachetime süresi kadar datayı cache içinde tut
                // defaul cache time 60 dk
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)
            };
            Cache.Add(new CacheItem(key, data), policy);

        }
        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }
        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern,
                RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = Cache.Where(p => regex.IsMatch(p.Key)).Select(p => p.Key).ToList();

            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        }
        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }
    }
}
