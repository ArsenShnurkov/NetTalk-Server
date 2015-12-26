using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class ExtTools
{
    public static char[] NumArr = new char[] { '٠', '١', '٢', '٣', '٤', '٥', '٦', '٧', '٨', '٩' };

    public static int? ToIntNullable(this string input)
    {
        int result;
        if (int.TryParse(input,out result))
            return result;
        else
            return null;
    }

    public static string EntitySort(this string input)
    {
        string[] t = input.Split(new char[] { ',' });
        for (int i = 0; i < t.Length; i++)
        {
            if (!t[i].StartsWith("it."))
                t[i] = "it." + t[i];
        }
        return string.Join(",", t);
    }

    public static TimeSpan ToTime(this string input)
    {
        string[] t = input.Split(new char[] { ':' });
        if (t.Length == 2)
            return new TimeSpan(Convert.ToInt32(t[0]), Convert.ToInt32(t[1]), 0);
        else
            return new TimeSpan(Convert.ToInt32(input), 0, 0);
    }

    public static string ToPersianNo(this int input)
    {
        string ch = input.ToString();
        string result = "";
        for (int i = 0; i < ch.Length; i++)
        {
            result += NumArr[Convert.ToByte(ch[i] + "")];
        }
        return result;
    }
    public static string ToPersianNo(this byte input)
    {
        string ch = input.ToString();
        string result = "";
        for (int i = 0; i < ch.Length; i++)
        {
            result += NumArr[Convert.ToByte(ch[i] + "")];
        }
        return result;
    }
    public static string ToPersianNo(this long input)
    {
        string ch = input.ToString();
        string result = "";
        for (int i = 0; i < ch.Length; i++)
        {
            result += NumArr[Convert.ToByte(ch[i] + "")];
        }
        return result;
    }
    public static string ToPersianNo(this short input)
    {
        string ch = input.ToString();
        string result = "";
        for (int i = 0; i < ch.Length; i++)
        {
            result += NumArr[Convert.ToByte(ch[i] + "")];
        }
        return result;
    }

    public static float? ToFloatNullable(this string input)
    {
        float result;
        if (float.TryParse(input, out result))
            return result;
        else
            return null;
    }

    public static long? ToLongNullable(this string input)
    {
        long result;
        if (long.TryParse(input, out result))
            return result;
        else
            return null;
    }

    public static byte? ToByteNullable(this string input)
    {
        byte result;
        if (byte.TryParse(input, out result))
            return result;
        else
            return null;
    }

    public static List<string> ToList(this string input, char seprator)
    {
        List<string> result = new List<string>();
        try
        {
            if (!string.IsNullOrEmpty(input))
            {
                string[] l = input.Split(new char[] { seprator });
                result.AddRange(l);
            }
        }
        catch { }
        return result;
    }

    public static List<string> ToList(this string input)
    {
        return input.ToList(',');
    }

    public static List<Guid> ToGuidArray(this string input, char seprator)
    {
        List<Guid> result = new List<Guid>();
        try
        {
            if (!string.IsNullOrEmpty(input))
            {
                string[] l = input.Split(new char[] { seprator }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string n in l)
                {
                    result.Add(new Guid(n));
                }
            }
        }
        catch { }
        return result;
    }

    public static List<Guid> ToGuidArray(this string input)
    {
        return input.ToGuidArray(',');
    }

    public static List<int> ToIntArray(this string input, char seprator)
    {
        List<int> result = new List<int>();
        try
        {
            if (!string.IsNullOrEmpty(input))
            {
                string[] l = input.Split(new char[] { seprator }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string n in l)
                {
                    result.Add(Convert.ToInt32(n));
                }
            }
        }
        catch { }
        return result;
    }

    public static List<int> ToIntArray(this string input)
    {
        return input.ToIntArray(',');
    }

    public static NetTalk.Common.Dates.NetTalkDate Miladi2PersianDate(this DateTime InputDate)
    {
        DateTime? dt = InputDate;
        return Miladi2PersianDate(dt);
    }

    public static string Miladi2Persian(this DateTime InputDate)
    {
        DateTime? dt = InputDate;
        return Miladi2Persian(dt);
    }

    public static string Miladi2Persian(this DateTime InputDate, string format)
    {
        DateTime? dt = InputDate;
        return Miladi2Persian(dt, format);
    }

    public static NetTalk.Common.Dates.NetTalkDate Miladi2PersianDate(this DateTime? InputDate)
    {
        if (InputDate.HasValue)
            return (new NetTalk.Common.Dates.NetTalkDate(InputDate.Value));
        else
            return null;
    }

    public static string Miladi2Persian(this DateTime? InputDate)
    {
        return Miladi2Persian(InputDate, "$dddd, $d $MMMM $yyyy $HH:$mm:$ss");
    }

    public static string Miladi2Persian(this DateTime? InputDate, string format)
    {
        if (InputDate.HasValue)
            return (new NetTalk.Common.Dates.NetTalkDate(InputDate.Value)).ToString(format);
        else
            return string.Empty;
    }

    public static string Persian2Miladi(this string input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            NetTalk.Common.Dates.NetTalkDate outpdate;
            bool result = NetTalk.Common.Dates.NetTalkDate.TryParse(input, out outpdate);
            if (result)
            {  
                input = outpdate.toDateTime().ToString();
            }
        }
        return input;
    }

    public static DateTime? Persian2MiladiDate(this string input)
    {
        DateTime? dtn = null;
        if (!string.IsNullOrEmpty(input))
        {
            NetTalk.Common.Dates.NetTalkDate outpdate;
            bool result = NetTalk.Common.Dates.NetTalkDate.TryParse(input, out outpdate);
            if (result)
            {
                dtn = outpdate.toDateTime();
            }
        }

        return dtn;
    }

    public static NetTalk.Common.Dates.NetTalkDate PersianDate(this string input)
    {
        NetTalk.Common.Dates.NetTalkDate outpdate = null;
        if (!string.IsNullOrEmpty(input))
        {
            bool result = NetTalk.Common.Dates.NetTalkDate.TryParse(input, out outpdate);
            if (!result)
                outpdate = null;
        }
        else
            outpdate = null;
        return outpdate;
    }

    public static string ToJs(this bool input)
    {
        return input.ToString().ToLower();
    }
}