using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Xml;

namespace NetTalk.Web.Codes
{
    public class Config
    {
        public static string PingDownloadUrl { get; set; }

        private static string _pic;
        public static string PictureFolder
        {
            get
            {
                if (string.IsNullOrEmpty(_pic))
                    _pic = Config.AppSetting.path + "system\\avatar\\";
                return _pic;
            }
        }

        #region XML Configuration
        private static DateTime FileLoadedDate { get; set; }
        private static string XMLFilePath { get; set; }

        public static void LoadPath()
        {
            XMLFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Application.xml");
            FileLoadedDate = DateTime.Now;
        }

        private static XMLConfig.config _AppSetting = null;
        public static XMLConfig.config AppSetting
        {
            get
            {
                if (_AppSetting == null || FileLoadedDate != System.IO.File.GetLastWriteTime(XMLFilePath))
                {
                    LoadXML(XMLFilePath);
                }

                return _AppSetting;
            }
            private set
            {
                _AppSetting = value;
            }
        }
        public static XMLConfig.config Reload()
        {
            _AppSetting = null;
            return AppSetting;
        }

        public static bool LoadXML(string URL)
        {
            bool Result = false;
            XmlSerializer rd = new XmlSerializer(typeof(XMLConfig.config));
            try
            {
                using (XmlReader reader = XmlReader.Create(URL))
                {
                    AppSetting = (XMLConfig.config)rd.Deserialize(reader);
                    FileLoadedDate = System.IO.File.GetLastWriteTime(URL);
                    Result = true;
                }
            }
            catch (Exception ex)
            {
                LogTools.Write(null, ex, "Config.LoadXML");
            }
            return Result;
        }

        public static bool SaveXML()
        {
            return SaveXML(XMLFilePath);
        }

        public static bool SaveXML(string URL)
        {
            bool Result = false;
            XmlSerializer rd = new XmlSerializer(typeof(XMLConfig.config));
            try
            {
                using (XmlWriter writer = XmlWriter.Create(URL))
                {
                    rd.Serialize(writer, AppSetting);
                    writer.Close();
                    Result = true;
                }
            }
            catch (Exception ex)
            {
                LogTools.Write(null, ex, "Config.SaveXML");
            }
            return Result;
        }
        #endregion
    }
}