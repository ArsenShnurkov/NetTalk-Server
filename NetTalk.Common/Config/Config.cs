using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;

namespace NetTalk.Common.Config
{
    public class NetTalkConfig
    {
        private string basePath;
        private string applicationPath;
        private string cacheName;
        private XmlDocument xmlconfig;

        public bool UseCache
        {
            get;
            set;
        }

        private void LoadConfig()
        {
            if (UseCache)
            {
                string[] tmp = applicationPath.Split(new char[] { '/' });
                cacheName = tmp[(tmp.Length - 1)];
                cacheName = cacheName.Replace(".", "_");
                cacheName = "config_" + cacheName;
                if (!string.IsNullOrEmpty(applicationPath))
                {
                    if (HttpContext.Current.Cache[cacheName] != null)
                    {
                        xmlconfig = HttpContext.Current.Cache[cacheName] as XmlDocument;
                    }
                    else
                    {
                        ReloadCache();
                    }
                }
                else
                {
                    throw new Exception("Application Path does not configed, Please set it before load.");
                }
            }
            else
                ReloadCache();
        }

        public void ReloadCache()
        {
            xmlconfig = new XmlDocument();
            xmlconfig.Load(HttpContext.Current.Server.MapPath(applicationPath));
            if (UseCache)
            {
                string[] tmp = applicationPath.Split(new char[] { '/' });
                cacheName = tmp[(tmp.Length - 1)];
                cacheName = cacheName.Replace(".", "_");
                cacheName = "config_" + cacheName;
                HttpContext.Current.Cache.Add(
                    cacheName, xmlconfig, null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                    System.Web.Caching.Cache.NoSlidingExpiration,
                    System.Web.Caching.CacheItemPriority.NotRemovable,
                    null);
            }
        }

        public void SaveConfig()
        {
            if (!string.IsNullOrEmpty(applicationPath))
            {
                xmlconfig.Save(HttpContext.Current.Server.MapPath(applicationPath));
                ReloadCache();
            }
            else
            {
                throw new Exception("Application Path does not configed, Please set it before load.");
            }
        }

        public NetTalkConfig()
        {
            UseCache = true;
            basePath = "/config/";
            applicationPath = "~/app_data/application.xml";
            LoadConfig();
        }

        public NetTalkConfig(string BasePath)
        {
            UseCache = true;
            basePath = BasePath;
            applicationPath = "~/app_data/application.xml";
            LoadConfig();
        }

        public NetTalkConfig(string BasePath, string ApplicationPath)
        {
            UseCache = true;
            basePath = BasePath;
            applicationPath = ApplicationPath;
            LoadConfig();
        }

        public void updateSetting(string XPath, string Value, bool IsCDA)
        {
            XmlNode node = xmlconfig.SelectSingleNode(basePath + XPath);
            node.InnerXml = "";
            if (IsCDA)
            {
                XmlCDataSection cda = xmlconfig.CreateCDataSection(Value);
                node.AppendChild(cda);
            }
            else
                node.InnerText = Value;
        }
        public void updateAttribute(string xpath, string att, string val)
        {
            XmlNode node = xmlconfig.SelectSingleNode(basePath + xpath);
            node.Attributes[att].Value = val;
        }

        public void updateSetting(string[] XPaths, string[] Values, bool IsCDA)
        {
            for (int iLoop = 0; iLoop < XPaths.Length; iLoop++)
            {
                updateSetting(XPaths[iLoop], Values[iLoop], IsCDA);
            }
        }

        public void updateRootAtt(string Name, string Value)
        {
            xmlconfig.DocumentElement.Attributes[Name].Value = Value;
        }

        public string getSetting(string XPath)
        {
            XmlNode node;
            node = xmlconfig.SelectSingleNode(basePath + XPath);
            if (node != null)
            {
                return node.InnerText;
            }
            else
            {
                return string.Empty;
            }
        }
        public string getAttribute(string XPath, string att)
        {
            XmlNode node;
            node = xmlconfig.SelectSingleNode(basePath + XPath);
            if (node != null)
            {
                if (node.Attributes[att] != null)
                    return node.Attributes[att].Value;
                else
                    return string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

        public string getRootAtt(string Name)
        {
            return xmlconfig.DocumentElement.Attributes[Name].Value;
        }

        public string[] getSettings(string XPath)
        {
            XmlNodeList nodes;
            nodes = xmlconfig.SelectNodes(basePath + XPath);
            string[] returnMe = new string[nodes.Count];
            for (int iLoop = 0; iLoop < nodes.Count; iLoop++)
            {
                if (nodes[iLoop] != null)
                {
                    returnMe[iLoop] = nodes[iLoop].InnerText;
                }
            }
            return returnMe;
        }
        public string[] getSetting(string[] XPaths)
        {
            string[] returnMe = new string[XPaths.Length];
            XmlNode node;
            for (int iLoop = 0; iLoop < XPaths.Length; iLoop++)
            {
                node = xmlconfig.SelectSingleNode(basePath + XPaths[iLoop]);
                if (node != null)
                {
                    returnMe[iLoop] = node.InnerText;
                }
            }
            return returnMe;
        }

        ~NetTalkConfig()
        {
            xmlconfig = null;
        }
    }
}
