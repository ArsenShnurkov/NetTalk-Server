using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using agsXMPP.protocol;
using agsXMPP.protocol.stream;

using agsXMPP.protocol.iq;
using agsXMPP.protocol.iq.auth;
using agsXMPP.protocol.iq.last;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.iq.vcard;
using agsXMPP.protocol.iq.register;
using agsXMPP.protocol.x.data;
using agsXMPP.protocol.extensions.html;

using agsXMPP.protocol.client;
using agsXMPP.protocol.x;
using agsXMPP.protocol.extensions.ping;
using agsXMPP.protocol.extensions.pubsub;
using agsXMPP.protocol.extensions.pubsub.@event;


using agsXMPP.Xml;
using agsXMPP.Xml.Dom;
using System.Text;

namespace NetTalk.Web.Codes.XML
{
    public class Server
    {
        public static IQ features(string username, IQ iq)
        {   
            iq.From = new agsXMPP.Jid(Codes.Config.AppSetting.domain);
            iq.To = new agsXMPP.Jid(username + "@" + Codes.Config.AppSetting.domain);

            iq.Type = IqType.result;
            Element el = new Element("identity");
            el.Attributes.Add("type", "pc");
            el.Attributes.Add("category", "client");
            iq.Query.AddChild(el);

            el = new Element("feature");
            el.Attributes.Add("var", "http://jabber.org/protocol/pubsub#access-roster");
            iq.Query.AddChild(el);

            el = new Element("feature");
            el.Attributes.Add("var", "msgoffline");
            iq.Query.AddChild(el);

            el = new Element("feature");
            el.Attributes.Add("var", "http://jabber.org/protocol/pubsub#auto-subscribe");
            iq.Query.AddChild(el);

            el = new Element("feature");
            el.Attributes.Add("var", "http://jabber.org/protocol/pubsub#presence-notifications");
            iq.Query.AddChild(el);

            el = new Element("feature");
            el.Attributes.Add("var", "jabber:iq:last");
            iq.Query.AddChild(el);

            el = new Element("feature");
            el.Attributes.Add("var", "jabber:iq:version");
            iq.Query.AddChild(el);

            el = new Element("feature");
            el.Attributes.Add("var", "urn:xmpp:ping");
            iq.Query.AddChild(el);

            el = new Element("feature");
            el.Attributes.Add("var", "http://jabber.org/protocol/ibb");
            iq.Query.AddChild(el);

            el = new Element("feature");
            el.Attributes.Add("var", "jabber:iq:ibb");
            iq.Query.AddChild(el);

            el = new Element("feature");
            el.Attributes.Add("var", "urn:xmpp:receipts");
            iq.Query.AddChild(el);

            return iq;
        }

        public static string OpenStream(string sid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<stream:stream from='");
            sb.Append(Config.AppSetting.domain);

            sb.Append("' xmlns='");
            sb.Append(agsXMPP.Uri.CLIENT);

            sb.Append("' xmlns:stream='");
            sb.Append(agsXMPP.Uri.STREAM);

            sb.Append("' id='");
            sb.Append(sid);

            sb.Append("'><stream:features><auth xmlns='http://jabber.org/features/iq-auth'/></stream:features>");
            return sb.ToString();
        }
    }
}