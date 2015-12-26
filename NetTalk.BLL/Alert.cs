using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetTalk.DAL;

namespace NetTalk.BLL
{
    public class Alert: BLLBase<NetTalk.DAL.TbAlerts>
    {
        NetTalk.DAL.Model.Alert Api;
        public Alert()
        {
            Api = new NetTalk.DAL.Model.Alert();
            BaseApi = Api;
            Key = "AlertId";
        }

        public BLLResult Insert(string Text, string AlertTime)
        {
            TbAlerts alert = new TbAlerts();
            alert.AlertTime = AlertTime.ToTime();
            alert.AlertText = Text;
            alert.AlertHTML = Text.Replace("\r\n", "<br />").Replace("\r", "<br />").Replace("\n", "<br />");
            alert.AlertId = NetTalk.GuidTools.Create();

            Api.Insert(alert);

            BLLResult res = new BLLResult();
            res.IsSuccess = (Api.Save() > 0);
            res.ErrorMessage = Api.SaveError;

            return res;
        }

        public BLLResult Update(Guid id,  string Text, string AlertTime)
        {
            TbAlerts alert = Find(id);
            alert.AlertTime = AlertTime.ToTime();
            alert.AlertText = Text;
            alert.AlertHTML = Text.Replace("\r\n", "<br />").Replace("\r", "<br />").Replace("\n", "<br />");

            BLLResult res = new BLLResult();
            res.IsSuccess = (Api.Save() > 0);
            res.ErrorMessage = Api.SaveError;

            return res;
        }

        public List<TbAlerts> ListFromTime(int LastTime)
        {
            int Hour, Minute, LHour, LMinute;

            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;

            DateTime s = DateTime.Now.AddSeconds(-LastTime);
            LHour = s.Hour;
            LMinute = s.Minute;

            TimeSpan FromT, ToT;
            FromT = new TimeSpan(LHour, LMinute, 0);
            ToT = new TimeSpan(Hour, Minute, 0);

            return Api.Table.Where(c => c.AlertTime >= FromT
                && c.AlertTime < ToT).ToList();
        }
    }
}
