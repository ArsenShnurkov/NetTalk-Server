using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace NetTalk.Web.Codes.Services
{
    public class BaseCacheService
    {
        public DateTime LastRun { get; set; }
        public DateTime Run { get; set; }
        public DateTime NextRun { get; set; }
        public bool IsFirstRun { get; set; }

        public delegate void AfterCommand();
        public event AfterCommand OnAfterSet;

        public delegate bool AfterCacheRemoved();
        public event AfterCacheRemoved OnCacheRemoved;

        public int WaitToNext { get; set; }
        public string Name { get; set; }

        public BaseCacheService(string Name, int WaitToNext)
        {
            this.Name = Name;
            this.WaitToNext = WaitToNext;
            IsFirstRun = true;
        }

        public void Set()
        {
            if (IsFirstRun)
            {
                Run = DateTime.Now;
                LastRun = DateTime.Now;
                IsFirstRun = false;
            }
            
            NextRun = DateTime.Now.AddSeconds(WaitToNext);
            HttpRuntime.Cache.Insert(
                Name,
                "0",
                null,
                NextRun,
                Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable, CacheRemoved);

            if(OnAfterSet != null)
                OnAfterSet();
        }

        private void CacheRemoved(string key, object value, CacheItemRemovedReason reason)
        {
            LastRun = DateTime.Now;
            bool DoNext = true;
            if (OnCacheRemoved != null)
                DoNext = OnCacheRemoved();

            if (DoNext)
                Set();
        }
    }
}