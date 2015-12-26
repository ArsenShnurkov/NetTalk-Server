using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTalk.Common.Dates
{
    public abstract class IDateInfo
    {
        public abstract string[] Days { get; }
        public abstract string[] Months { get; }
        public abstract string AM { get; }
        public abstract string PM { get; }
    }

    public class NetTalkDateInfo_Persian : IDateInfo
    {
        private string[] days;
        private string[] months;

        public NetTalkDateInfo_Persian()
        {
            days = new string[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
            months = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        }

        public override string[] Days
        {
            get { return days; }
        }

        public override string[] Months
        {
            get { return months; }
        }

        public override string AM
        {
            get { return "ق.ظ"; }
        }

        public override string PM
        {
            get { return "ب.ظ"; }
        }
    }

    public class NetTalkDateInfo_Arabic : IDateInfo
    {
        private string[] days;
        private string[] months;

        public NetTalkDateInfo_Arabic()
        {
            days = new string[] { "اِلأَحَّد", "اِلأِثنين", "اِثَّلاثا", "اِلأَربِعا", "اِلخَميس", "اِجُّمعَة", "اِسَّبِت" };
            months = new string[] { "محرم", "صفر", "ربيع الاول", "ربيع الثاني", "جمادي الاول", "جمادي الثاني", "رجب", "شعبان", "رمضان", "شوال", "ذي القعدة", "ذي الحجة" };
        }
        public override string[] Days
        {
            get { return days; }
        }

        public override string[] Months
        {
            get { return months; }
        }

        public override string AM
        {
            get { return "ص"; }
        }

        public override string PM
        {
            get { return "م"; }
        }
    }

    public class NetTalkDateInfo_English : IDateInfo
    {
        private string[] days;
        private string[] months;

        public NetTalkDateInfo_English()
        {
            days = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        }
        public override string[] Days
        {
            get { return days; }
        }

        public override string[] Months
        {
            get { return months; }
        }

        public override string AM
        {
            get { return "AM"; }
        }

        public override string PM
        {
            get { return "PM"; }
        }
    }

    public class NetTalkDateInfo
    {
        public enum Info
        {
            Persian,
            Arabic,
            English
        }

        private static Dictionary<Info, IDateInfo> cache = new Dictionary<Info, IDateInfo>();
        public static IDateInfo GetInfo(Info DateInfo)
        {
            IDateInfo result;
            switch (DateInfo)
            {
                case Info.Persian:
                    if (!cache.Keys.Contains(Info.Persian))
                        cache[Info.Persian] = new NetTalkDateInfo_Persian();
                    result = cache[Info.Persian];
                    break;
                case Info.Arabic:
                    if (!cache.Keys.Contains(Info.Arabic))
                        cache[Info.Arabic] = new NetTalkDateInfo_Arabic();
                    result = cache[Info.Arabic];
                    break;
                case Info.English:
                    if (!cache.Keys.Contains(Info.English))
                        cache[Info.English] = new NetTalkDateInfo_English();
                    result = cache[Info.English];
                    break;
                default:
                    if (!cache.Keys.Contains(Info.Persian))
                        cache[Info.Persian] = new NetTalkDateInfo_Persian();
                    result = cache[Info.Persian];
                    break;
            }
            return result;
        }
    }
}
