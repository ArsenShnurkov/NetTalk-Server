using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NetTalk.Common.Validation
{
    public class NetTalkIsValid
    {
        public static bool Match(string txt, string pattern)
        {
            bool FoundMatch = true;
            if (!IsNull(txt))
            {
                try
                {
                    FoundMatch = Regex.IsMatch(txt, pattern);
                }
                catch { }
            }
            return FoundMatch;
        }

        public static bool HasLength(string msg, int Length, bool CanNull)
        {
            if (!IsNull(msg))
                return (msg.Length <= Length);
            else
                return CanNull;
        }

        public static bool HasMinLength(string msg, int Length, bool CanNull)
        {
            if (!IsNull(msg))
                return (msg.Length >= Length);
            else
                return CanNull;
        }

        public static bool HasMinMaxLength(string msg, int min, int max, bool CanNull)
        {
            if (!IsNull(msg))
                return (msg.Length >= min) && (msg.Length <= max);
            else
                return CanNull;
        }

        public static bool IsNull(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static bool IsEmail(string input)
        {
            return Match(input, NetTalkPatterns.Email);
        }

        public static bool IsUrl(string input)
        {
            return Match(input, NetTalkPatterns.Url);
        }

        public static bool IsDate(string input)
        {
            return Match(input, NetTalkPatterns.Date);
        }

        public static bool IsDatetime(string input)
        {
            return Match(input, NetTalkPatterns.DateTime);
        }

        public static bool IsDateTimeFactor(string input)
        {
            return Match(input, NetTalkPatterns.DateTimeFactor);
        }

        public static bool IsTime(string input)
        {
            return Match(input, NetTalkPatterns.Time);
        }

        public static bool IsLatinCharAndNum(string input)
        {
            return Match(input, NetTalkPatterns.LatinCharAndNum);
            
        }

        public static bool IsLatinChar(string input)
        {
            return Match(input, NetTalkPatterns.LatinChar);
        }

        public static bool IsFarsiChar(string input)
        {
            return Match(input, NetTalkPatterns.FarsiChar);
        }

        public static bool IsNumber(string input)
        {
            return Match(input, NetTalkPatterns.Number);
        }

        public static bool IsDigit(string input)
        {
            return Match(input, NetTalkPatterns.Digit);
        }
    }
}
