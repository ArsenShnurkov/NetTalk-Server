using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace NetTalk.Web.Codes
{
    public class Tools
    {
        public static string CreateSessionId()
        {
            RandomNumberGenerator RNG = RandomNumberGenerator.Create();
            byte[] buf = new byte[4];
            RNG.GetBytes(buf);

            return agsXMPP.util.Hash.HexToString(buf);
        }
    }
}