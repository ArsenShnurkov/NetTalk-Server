using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NetTalk
{
    public class GuidTools
    {
        //This function create a sequential GUID using SQL Server 2005,2008 DLL Api;

        [DllImport("rpcrt4.dll", SetLastError = true)]
        static extern int UuidCreateSequential(out Guid guid);

        public static Guid Create()
        {
            const int RPC_S_OK = 0;
            Guid g;
            int hr = UuidCreateSequential(out g);
            if (hr != RPC_S_OK)
                throw new ApplicationException
                  ("UuidCreateSequential failed: " + hr);
            return g;
        }
    }
}
