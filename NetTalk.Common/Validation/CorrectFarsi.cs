using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTalk.Common.Validation
{
    public class Correct
    {
        public static string Farsi(string input)
        {
            if (!string.IsNullOrEmpty(input))
                return input.Replace("ي", "ی").Replace("ك", "ک");
            else
                return input;
        }
    }
}
