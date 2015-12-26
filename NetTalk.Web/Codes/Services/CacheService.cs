using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Net;

namespace NetTalk.Web.Codes.Services
{
    public class CacheService
    {
        public static BaseCacheService PingServer;
        public static bool ContinuePing = true;

        public static void Ping()
        {
            try
            {
                /*WebClient wc = new WebClient();
                wc.DownloadString(Config.PingDownloadUrl);*/
            }
            catch
            {
            }
        }

        public static void StartAllCache()
        {
            if (PingServer == null)
            {
                if (Config.AppSetting.serverup)
                {
                    ContinuePing = true;
                    PingServer = new BaseCacheService("PingServer", 120);
                    PingServer.OnCacheRemoved += new BaseCacheService.AfterCacheRemoved(PingServer_OnCacheRemoved);
                    PingServer.OnAfterSet += new BaseCacheService.AfterCommand(PingServer_OnAfterSet);
                    PingServer.Set();
                }
            }
        }

        static void PingServer_OnAfterSet()
        {
            try
            {
                DateTime dt = DateTime.Today;
                bool result = false;
                if (dt.Year == Config.AppSetting.lastlogclear.year)
                {
                    if (dt.Month != Config.AppSetting.lastlogclear.month)
                    {
                        result = true;
                    }
                }
                else
                    result = true;

                if (result)
                {
                    NetTalk.BLL.Log api = new NetTalk.BLL.Log();
                    api.ClearLastMonthLog();

                    Config.AppSetting.lastlogclear.month = Convert.ToByte(dt.Month);
                    Config.AppSetting.lastlogclear.year = Convert.ToUInt16(dt.Year);

                    Config.SaveXML();
                }
            }
            catch (Exception ex)
            {
                LogTools.Write(null, ex, "PingServer_OnAfterSet");
            }
        }

        static bool PingServer_OnCacheRemoved()
        {
            Ping();

            if (!ThreadTools.Main.ThreadIsAlive)
            {
                ThreadTools.Main.Start();
            }

            XML.Messages.SendAlerts(120);

            return ContinuePing;
        }
    }
}