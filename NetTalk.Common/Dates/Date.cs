using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

using NetTalk.Common.Validation;
namespace NetTalk.Common.Dates
{
    public class NetTalkDate
    {
        private int _year, _day, _month, _hour, _minute, _seconds, _milisecond, _dayofWeek;
        private int maxYear, maxMonth, maxDay;
        private int minYear, minMonth, minDay;
        public IDateInfo DateInfo;

        private Calendar _calendar;
        public Calendar DateCalendar
        {
            get { return _calendar; }
            set
            {
                _calendar = value;
            }
        }

        private void ResetCalendar()
        {
            DateTime dt;
            dt = DateCalendar.MaxSupportedDateTime;
            maxYear = DateCalendar.GetYear(dt);
            maxMonth = DateCalendar.GetMonth(dt);
            maxDay = DateCalendar.GetDayOfMonth(dt);

            dt = DateCalendar.MinSupportedDateTime;
            minYear = DateCalendar.GetYear(dt);
            minMonth = DateCalendar.GetMonth(dt);
            minDay = DateCalendar.GetDayOfMonth(dt);
        }
       
        private void SetDate(DateTime dt)
        {
            _year = DateCalendar.GetYear(dt);
            _month = DateCalendar.GetMonth(dt);
            _day = DateCalendar.GetDayOfMonth(dt);
            _dayofWeek = (int)DateCalendar.GetDayOfWeek(dt);
            _hour = dt.Hour;
            _minute = dt.Minute;
            _seconds = dt.Second;
            MiliSeconds = dt.Millisecond;
        }

        public int MonthLength
        {
            get
            {
                return DateCalendar.GetDaysInMonth(Year, Month);
            }
        }

        private void FixOne(ref int one, int unit, ref int next)
        {
            if (one < 0 || one >= unit)
            {
                if (one < 0)
                {
                    while (one < 0)
                    {
                        one += unit;
                        next--;
                    }
                }
                else
                {
                    while (one >= unit)
                    {
                        one -= unit;
                        next++;
                    }
                }
            }
        }

        private void FixMonthYear(ref int year, ref int month)
        {
            if (year > maxYear || year < minYear)
            {
                throw new Exception("مقدار سال نا معتبر است");
            }
            int maxMonth = DateCalendar.GetMonthsInYear(year);
            if (month < 1 || month > maxMonth)
            {
                if (month < 1)
                {
                    while (month < 1)
                    {
                        year--;
                        maxMonth = DateCalendar.GetMonthsInYear(year);
                        month += maxMonth;
                    }
                }
                else
                {
                    while (month > maxMonth)
                    {
                        year++;
                        maxMonth = DateCalendar.GetMonthsInYear(year);
                        month -= maxMonth;
                    }
                }
            }
            if (year > maxYear || year < minYear)
            {
                throw new Exception("مقادیر سال و ماه نامعتبر است");
            }
        }

        private void FixAll(ref int year, ref int month, ref int day, ref int hour, ref int minute, ref int second, ref int milisecond)
        {
            FixOne(ref milisecond, 1000, ref second);
            FixOne(ref second, 60, ref minute);
            FixOne(ref minute, 60, ref hour);
            FixOne(ref hour, 24, ref day);
            FixMonthYear(ref year, ref month);
            int maxDay = DateCalendar.GetDaysInMonth(year, month);
            if (day < 1 || day > maxDay)
            {
                if (day < 1)
                {
                    while (day < 1)
                    {
                        month--;
                        FixMonthYear(ref year, ref month);
                        maxDay = DateCalendar.GetDaysInMonth(year, month);
                        day += maxDay;
                    }
                }
                else
                {
                    while (day > maxDay)
                    {
                        day -= maxDay;
                        month++;
                        FixMonthYear(ref year, ref month);
                        maxDay = DateCalendar.GetDaysInMonth(year, month);
                    }
                }
            }
            FixMonthYear(ref year, ref month);
        }

        private static string TwoDigit(int input)
        {
            string twoDJ = "";
            int len = input.ToString().Length;
            if (len == 1)
                twoDJ = input.ToString().Insert(0, "0");
            else if(len == 2)
                twoDJ = input.ToString();
            else if (len > 2)
            {

            }
            return twoDJ;
        }

        private string Format(string expression)
        {
            switch (expression)
            {
                case "F":
                case "f":
                    expression = Format("$dddd, $d $MMMM $yyyy $HH:$mm:$ss $g");
                    break;
                case "S":
                case "s":
                    expression = Format("$yyyy/$MM/$dd $HH:$mm:$ss $g");
                    break;
                default:
                    expression = Regex.Replace(expression, "\\$d{4}", DateInfo.Days[this.DayOfWeek]);
                    expression = Regex.Replace(expression, "\\$d{2}", TwoDigit(Day));
                    expression = Regex.Replace(expression, "\\$d{1}", Day.ToString());
                    
                    expression = Regex.Replace(expression, "\\$M{4}", DateInfo.Months[(this.Month - 1)]);
                    expression = Regex.Replace(expression, "\\$M{2}", TwoDigit(Month));
                    expression = Regex.Replace(expression, "\\$M{1}", Month.ToString());

                    expression = Regex.Replace(expression, "\\$y{4}", Year.ToString());
                    expression = Regex.Replace(expression, "\\$y{2}", TwoDigitYear.ToString());

                    expression = Regex.Replace(expression, "\\$H{2}", TwoDigit(Hour));
                    expression = Regex.Replace(expression, "\\$H{1}", Hour.ToString());

                    expression = Regex.Replace(expression, "\\$h{2}", TwoDigit(Hour12));
                    expression = Regex.Replace(expression, "\\$h{1}", Hour12.ToString());

                    expression = Regex.Replace(expression, "\\$m{2}", TwoDigit(Minute));
                    expression = Regex.Replace(expression, "\\$m{1}", Minute.ToString());

                    expression = Regex.Replace(expression, "\\$s{2}", TwoDigit(Seconds));
                    expression = Regex.Replace(expression, "\\$s{1}",Seconds.ToString());

                    expression = Regex.Replace(expression, "\\$g{1}", this.Daylight);
                    break;
            }
            return expression;
        }

        public NetTalkDate(int year, int month, int day)
            : this(year, month, day, 0, 0, 0, 0, new PersianCalendar(), NetTalkDateInfo.GetInfo(NetTalkDateInfo.Info.Persian))
        {
        }

        public NetTalkDate(int year, int month, int day, Calendar Cal, IDateInfo DInfo)
            : this(year, month, day, 0, 0, 0, 0, Cal, DInfo)
        {
        }

        public NetTalkDate(int year, int month, int day, int hour, int minute, int second, int milisecond)
            : this(year, month, day, hour, minute, second, milisecond, new PersianCalendar(), NetTalkDateInfo.GetInfo(NetTalkDateInfo.Info.Persian))
        {
        }

        public NetTalkDate(int year, int month, int day, int hour, int minute, int second, int milisecond, Calendar Cal, IDateInfo DInfo)
        {
            DateCalendar = Cal;
            DateInfo = DInfo;
            ResetCalendar();

            _year = year;
            _month = month;
            _day = day;
            _hour = hour;
            _minute = minute;
            _seconds = second;
            MiliSeconds = milisecond;
            _dayofWeek = (int)DateCalendar.GetDayOfWeek(this.toDateTime());
        }

        public NetTalkDate()
            : this(new PersianCalendar(), NetTalkDateInfo.GetInfo(NetTalkDateInfo.Info.Persian), DateTime.Now)
        {
        }

        public NetTalkDate(DateTime dt)
            : this(new PersianCalendar(), NetTalkDateInfo.GetInfo(NetTalkDateInfo.Info.Persian), dt)
        {
        }

        public NetTalkDate(Calendar Cal, IDateInfo DInfo)
            : this(Cal, DInfo, DateTime.Now)
        {
        }

        public NetTalkDate(Calendar Cal, IDateInfo DInfo, DateTime dt)
        {
            DateCalendar = Cal;
            DateInfo = DInfo;
            ResetCalendar();

            SetDate(dt);
        }

        public int Day
        {
            get { return _day; }
            set
            {
                _day = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public int DayOfWeek
        {
            get
            {
                return _dayofWeek;
            }
        }

        public int Month
        {
            get { return _month; }
            set
            {
                _month = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public int HijriAdjust
        {
            set
            {
                if (this.DateCalendar.GetType() == typeof(HijriCalendar))
                {
                    HijriCalendar cal = (HijriCalendar)this.DateCalendar;
                    cal.HijriAdjustment = value;
                    this.DateCalendar = cal;
                    this.ResetCalendar();
                }
            }
        }

        public int Hour
        {
            get { return _hour; }
            set
            {
                _hour = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public int Hour12
        {
            get
            {
                if (_hour > 12)
                    return _hour - 12;
                else
                    return _hour;
            }
        }

        public int Minute
        {
            get { return _minute; }
            set
            {
                _minute = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public int Seconds
        {
            get { return _seconds; }
            set
            {
                _seconds = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public int MiliSeconds
        {
            get { return _milisecond; }
            set
            {
                _milisecond = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public bool IsLeapYear
        {
            get
            {
                return DateCalendar.IsLeapYear(Year);
            }
        }

        public bool IsLeapMonth
        {
            get
            {
                return DateCalendar.IsLeapMonth(Year, Month);
            }
        }

        public bool IsLeapDay
        {
            get
            {
                return DateCalendar.IsLeapDay(Year, Month, Day);
            }
        }

        public int TwoDigitYear
        {
            get
            {
                if (Year.ToString().Length > 2)
                    return Convert.ToInt32(Year.ToString().Substring(2, 2));
                else
                    return Year;
            }
        }

        public string Daylight
        {
            get
            {
                if (Hour > 12)
                    return DateInfo.PM;
                else
                    return DateInfo.AM;
            }
        }

        public DateTime toDateTime()
        {
            return DateCalendar.ToDateTime(Year, Month, Day, Hour, Minute, Seconds, MiliSeconds);
        }

        public new string ToString()
        {
            return Format("s");
        }

        public string ToString(string format)
        {
            return Format(format);
        }

        public override int GetHashCode()
        {
            return this.toDateTime().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.toDateTime().Equals(obj);
        }

        public static NetTalkDate Now
        {
            get { return new NetTalkDate(); }
        }

        public static bool TryParse(string dt, out NetTalkDate result)
        {
            bool HasResult = false;
            result = null;
            try
            {
                if (NetTalkIsValid.IsDate(dt))
                {
                    Regex rg = new Regex(NetTalkPatterns.Date);
                    int y, m, d;
                    Match r = rg.Match(dt);
                    y = Convert.ToInt32(r.Groups[1].Value);
                    m = Convert.ToInt32(r.Groups[2].Value);
                    d = Convert.ToInt32(r.Groups[3].Value);
                    result = new NetTalkDate(y, m, d);
                    HasResult = true;
                }
                else if (NetTalkIsValid.IsDatetime(dt))
                {
                    Regex rg = new Regex(NetTalkPatterns.DateTime);
                    int y, m, d, h, min, s;

                    Match r = rg.Match(dt);
                    y = Convert.ToInt32(r.Groups[1].Value);
                    m = Convert.ToInt32(r.Groups[2].Value);
                    d = Convert.ToInt32(r.Groups[3].Value);
                    h = Convert.ToInt32(r.Groups[4].Value);
                    min = Convert.ToInt32(r.Groups[5].Value);
                    s = Convert.ToInt32(r.Groups[6].Value);
                    result = new NetTalkDate(y, m, d, h, min, s, 0);
                    HasResult = true;
                }
                else if (NetTalkIsValid.IsDateTimeFactor(dt))
                {
                    Regex rg = new Regex(NetTalkPatterns.DateTimeFactor);
                    int y, m, d, h, min, s;

                    Match r = rg.Match(dt);
                    y = Convert.ToInt32(r.Groups[1].Value);
                    m = Convert.ToInt32(r.Groups[2].Value);
                    d = Convert.ToInt32(r.Groups[3].Value);
                    h = Convert.ToInt32(r.Groups[4].Value);
                    min = Convert.ToInt32(r.Groups[5].Value);
                    s = 0;
                    result = new NetTalkDate(y, m, d, h, min, s, 0);
                    HasResult = true;
                }
            }
            catch { }

            return HasResult;
        }
    }
}
