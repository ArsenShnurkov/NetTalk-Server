using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTalk.Common.Validation
{
    public class NetTalkPatterns
    {
        public const string Date = "\\A(\\d{4})[\\\\/\\-](\\d{1,2})[\\\\/\\-](\\d{1,2})\\z";
        public const string DateTime = "\\A(\\d{4})[\\\\/\\-](\\d{1,2})[\\\\/\\-](\\d{1,2})\\s(\\d{1,2}):(\\d{1,2}):(\\d{1,2})\\z";
        public const string DateTimeFactor = "\\A(\\d{4})\\/(\\d{1,2})\\/(\\d{1,2})\\-(\\d{1,2}):(\\d{1,2})\\z";
        public const string Time = "\\A(\\d{1,2}):(\\d{1,2}):(\\d{1,2})\\Z";
        public const string Email = "\\A\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*\\z";
        public const string Url = "\\Ahttp(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&amp;=]*)?\\z";
        public const string LatinCharAndNum = "\\A[\\sa-zA-Z0-9\\.]*\\z";
        public const string Number = "\\A(?:-?(?:\\d+|\\d{1,3}(?:,\\d{3})+)(?:\\.\\d+)?)\\z";
        public const string Digit = "\\A\\d*\\z";
        public const string LatinChar = "\\A[\\sa-zA-Z]*\\z";
        public const string FarsiChar = "\\A[\\sگوکذىىلآدءٍفإجژچپشذزیثبلاهتنمئدخحضقسفعرصطغظ]*\\z";
    }
}
