using System;

using System.Web;

namespace RapidPay.Helper
{
    public class CacheHelper<T>
    {
        private string _key = "";

        public CacheHelper(string idCacheKey)
        {
            _key = idCacheKey;
        }

        public bool CheckCache()
        {
            return (HttpRuntime.Cache.Get(_key) != null);
        }

        public T GetToCache()
        {
            return (T)HttpRuntime.Cache.Get(_key);
        }

        public void SetToCache(T data)
        {
            HttpRuntime.Cache.Add(_key, data, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
          //  HttpRuntime.Cache.Insert("key", data, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromHours(1));
        }
        public void SetToCacheToken(T data)
        {
            HttpRuntime.Cache.Add(_key, data, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);

        }

        public void DeleteCache()
        {
            HttpRuntime.Cache.Remove(_key);
        }
    }
}