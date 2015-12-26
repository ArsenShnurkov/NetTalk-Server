using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using agsXMPP.Xml;
using System.Net.Sockets;
using agsXMPP.protocol.client;
using System.Net;
using agsXMPP.Xml.Dom;
using System.Text;

namespace NetTalk.Web.Codes.ThreadTools
{
    public class Connection
    {
        #region Properties
        private const int BUFFERSIZE = 1024;
        private StreamParser streamParser;
        private byte[] buffer;

        public Socket ConnectionSocket
        {
            get;
            private set;
        }

        public DateTime StartTime { get; set; }

        public string IPAddress
        {
            get
            {
                return ((IPEndPoint)ConnectionSocket.RemoteEndPoint).Address.ToString();
            }
        }

        public string IPPort
        {
            get
            {
                return ((IPEndPoint)ConnectionSocket.RemoteEndPoint).Port.ToString();
            }
        }

        public string SessionId
        {
            get;
            set;
        }

        public bool Authenticated
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public ShowType UserStatus
        {
            get;
            set;
        }

        public string UserStatusString
        {
            get { return UserStatus.ToString(); }
        }

        public string UserStatusText
        {
            get;
            set;
        }

        public bool IsConnected
        {
            get
            {
                if (ConnectionSocket != null)
                    return ConnectionSocket.Connected;
                else
                    return false;
            }
        }
        #endregion

        #region Constructor
        public Connection(Socket UserSocket, string SID)
        {
            streamParser = new StreamParser();
            streamParser.OnStreamStart += new StreamHandler(streamParser_OnStreamStart);
            streamParser.OnStreamEnd += new StreamHandler(streamParser_OnStreamEnd);
            streamParser.OnStreamElement += new StreamHandler(streamParser_OnStreamElement);

            SessionId = SID;
            buffer = new byte[BUFFERSIZE];
            ConnectionSocket = UserSocket;

            this.Authenticated = false;
            this.Username = "";
            this.UserStatus = ShowType.NONE;
            this.UserStatusText = "";
            this.StartTime = DateTime.Now;

            ConnectionSocket.BeginReceive(buffer, 0, BUFFERSIZE, 0, new AsyncCallback(ReadCallback), null);
        }
        #endregion

        #region Listen to Stream Connection
        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                int bytesRead = ConnectionSocket.EndReceive(ar);
                if (bytesRead > 0)
                {
                    streamParser.Push(buffer, 0, bytesRead);
                    ConnectionSocket.BeginReceive(buffer, 0, BUFFERSIZE, 0, new AsyncCallback(ReadCallback), null);
                }
            }
            catch (Exception ex)
            {
                LogTools.Write(this.SessionId, ex, "Connection.ReadCallback");
            }
        }

        private void streamParser_OnStreamStart(object sender, Node e)
        {
            Send(XML.Server.OpenStream(SessionId));
        }

        private void streamParser_OnStreamEnd(object sender, Node e)
        {
            
            Users.Online.Remove(this);
            if (this.Authenticated && !string.IsNullOrEmpty(this.Username))
            {
                XML.Rosters.ChangeStatus(this.Username, this.UserStatusText, this.UserStatus, false);
                XML.Rosters.SendStatus(this.Username);
            }
        }

        private void streamParser_OnStreamElement(object sender, Node e)
        {
            LogTools.Write(this.SessionId, e.ToString());
            if (e.GetType() == typeof(Message))
            {
                XML.Proccess.Messages(this.SessionId, this.Username, e as Message);
            }
            else if (e.GetType() == typeof(Presence))
            {
                XML.Proccess.Presences(this.SessionId, this.Username, e as Presence);
            }
            else if (e.GetType() == typeof(IQ))
            {
                IQ iq = e as IQ;
                XML.Proccess.IQs(this.SessionId, this.Username, iq);
            }
        }
        #endregion

        #region Send To Stream Connection
        public void Stop()
        {
            Send("</stream:stream>");
            ConnectionSocket.Shutdown(SocketShutdown.Both);
            ConnectionSocket.Close();
        }

        public void Send(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
                Send(data[i]);
        }

        public void Send(string data)
        {
            try
            {
                if (!string.IsNullOrEmpty(data))
                {
                    byte[] byteData = Encoding.UTF8.GetBytes(data);
                    ConnectionSocket.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), null);
                    LogTools.Write(this.SessionId, data);
                }
            }
            catch (Exception ex)
            {
                LogTools.Write(this.SessionId, ex, "Connection.Send");
            }
        }

        public void Send(Element el)
        {
            Send(el.ToString());
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                int bytesSent = ConnectionSocket.EndSend(ar);
            }
            catch (ObjectDisposedException objex)
            {
                XML.Rosters.ChangeStatus(this.Username, this.UserStatusText, this.UserStatus, false);
                Users.Online.Remove(this);
                XML.Rosters.SendStatus(this.Username);

                LogTools.Write(this.SessionId, objex, "Connection.SendCallback");
            }
            catch (SocketException sockex)
            {
                if (sockex.ErrorCode == 10054)
                {
                    XML.Rosters.ChangeStatus(this.Username, this.UserStatusText, this.UserStatus, false);
                    Users.Online.Remove(this);
                    XML.Rosters.SendStatus(this.Username);
                }
                else
                {
                    LogTools.Write(this.SessionId, sockex, "Connection.SendCallback");
                }
            }
            catch (Exception ex)
            {
                LogTools.Write(this.SessionId, ex, "Connection.SendCallback");
            }
        }
        #endregion
    }
}