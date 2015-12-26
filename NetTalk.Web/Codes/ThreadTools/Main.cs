using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace NetTalk.Web.Codes.ThreadTools
{
    public class Main
    {
        public static Thread WorkingThread;
        private static ManualResetEvent ThreadEvent = new ManualResetEvent(false);
        private static Socket Listener;
        private static bool ContinueListening = false;
        private static string _LastErrorMessage;

        public static bool ThreadIsRun
        {
            get
            {
                return ContinueListening;
            }
            private set
            {
                ContinueListening = value;
            }
        }
        public static string LastErrorMessage
        {
            get
            {
                return _LastErrorMessage;
            }
            set
            {
                _LastErrorMessage = value;
            }
        }

        public static void Start()
        {
            if (!ThreadIsRun && !ThreadIsAlive)
            {
                Config.PingDownloadUrl = Config.AppSetting.domain + "/text.ashx";
                
                ThreadIsRun = true;
                ThreadStart d_RunThread = new ThreadStart(Linten);
                WorkingThread = new Thread(d_RunThread);
                WorkingThread.Priority = ThreadPriority.Highest;
                WorkingThread.Name = "IM Server: Listen to 5222";
                WorkingThread.Start();
            }
        }

        public static void Stop()
        {
            try
            {
                Services.CacheService.ContinuePing = false;
                ThreadIsRun = false;
                ThreadEvent.Set();
                int count = Users.Online.Count;
                for (int i = 0; i < count; i++)
                {
                    if (Users.Online[i].IsConnected)
                    {
                        try
                        {
                            Users.Online[i].Stop();
                        }
                        catch { }
                    }
                }
                Users.Online.Clear();
            }
            catch (Exception ex)
            {
                LogTools.Write(null, ex, "Main.Stop");
            }
            
        }

        public static bool ThreadIsAlive
        {
            get
            {
                if (WorkingThread != null)
                    return WorkingThread.IsAlive;
                else
                    return false;
            }
        }

        private static void Linten()
        {
            IPEndPoint RemoteUsers = new IPEndPoint(IPAddress.Any, 5222);
            Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                Listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                Listener.Bind(RemoteUsers);
                Listener.Listen(10);

                ThreadIsRun = true;
                while (ContinueListening)
                {
                    ThreadEvent.Reset();

                    Listener.BeginAccept(new AsyncCallback(AcceptCallback), null);

                    ThreadEvent.WaitOne();
                }
            }
            catch (Exception ex)
            {
                ThreadIsRun = false;
                LastErrorMessage = ex.Message;
            }
        }

        private static void AcceptCallback(IAsyncResult asyncResult)
        {
            ThreadEvent.Set();
            Socket NewUser = Listener.EndAccept(asyncResult);
            Users.Online.Add(new Connection(NewUser, Tools.CreateSessionId()));
        }
    }
}