using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetTalk.DAL;

namespace NetTalk.BLL
{
    public class Log : BLLBase<TbLogs>
    {
        NetTalk.DAL.Model.Log Api;
        public Log()
        {
            Api = new NetTalk.DAL.Model.Log();
            BaseApi = Api;
            Key = "LogId";
        }

        public BLLResult Insert(string ip, string sessionid, Guid? UserId, string text)
        {
            TbLogs lg = new TbLogs();
            lg.LogId = NetTalk.GuidTools.Create();
            lg.LogSessionId = sessionid;
            lg.LogText = text;
            lg.LogUserId = UserId;
            lg.LogIP = ip;
            lg.LogDate = DateTime.Now;

            Api.Insert(lg);

            BLLResult res = new BLLResult();
            res.IsSuccess = Api.Save() > 0;
            res.ErrorMessage = Api.SaveError;

            return res;
        }

        public List<VwLog> ListVw(string DefaultSort, DynamicSearch.ConditionList Search, string Sort, int PageIndex, int PageSize)
        {
            if (string.IsNullOrEmpty(Sort))
                Sort = DefaultSort;

            return Api.FindVw(Search.GetString(), Search.GetParam()).Skip(PageSize * PageIndex).Take(PageSize).ToList();
        }

        public int ListVwCount(DynamicSearch.ConditionList Search)
        {
            return Api.FindVw(Search.GetString(), Search.GetParam()).Count();
        }

        public BLLResult ClearLastMonthLog()
        {
            DateTime Today = DateTime.Today;
            DateTime PrevMonth = Today.AddDays(-30);

            var q = Api.Table.Where(c => c.LogDate < Today && c.LogDate >= PrevMonth);
            foreach (TbLogs lg in q)
                Api.Delete(lg);

            BLLResult res = new BLLResult();
            res.IsSuccess = (Api.Save() > 0);
            res.ErrorMessage = Api.SaveError;

            return res;
        }
    }
}
