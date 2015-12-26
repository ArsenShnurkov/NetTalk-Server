using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

namespace NetTalk.Web.Codes
{
    public class ImageTools
    {
        public static bool IsPictureExist(string name)
        {
            return File.Exists(Config.PictureFolder + name);
        }

        public static string ToBase64(string name)
        {
            string result = "";
            try
            {
                result = File.ReadAllText(Config.PictureFolder + name);
            }
            catch (Exception ex)
            {
                LogTools.Write(null, ex, "ImageTools.ToBase64");
            }
            return result;
        }

        public static string SaveAvatar(string b64, out bool IsSaved)
        {
            string fname = "";
            IsSaved = false;
            if (!IsPictureExist(fname))
            {
                IsSaved = SaveFromBase64(b64, out fname);
            }
            return fname;
        }

        public static bool SaveFromBase64(string b64, out string name)
        {
            bool result = false;
            byte[] buffer = Convert.FromBase64String(b64);
            name = NetTalk.Common.Hash.NetTalkHash.HashData(buffer, "sha1");
            bool IsImage = false;
            float kbyte = Convert.ToSingle(buffer.Length) / 1024f;
            try
            {
                MemoryStream st = new MemoryStream();
                st.Write(buffer, 0, buffer.Length);
                Image img = Image.FromStream(st);
                st.Close();
                st.Dispose();
                IsImage = true;
                if (kbyte > 20)
                {
                    Image Thumb = NetTalk.Common.ImageTools.NetTalkCropImage.Thumbnail(img, true, 150);
                    st = new MemoryStream();
                    Thumb.Save(st, NetTalk.Common.ImageTools.NetTalkEncoder.JpegEncoderInfo, NetTalk.Common.ImageTools.NetTalkEncoder.EncoderParams(85));

                    buffer = st.ToArray();
                    b64 = Convert.ToBase64String(buffer);

                    st.Close();
                    st.Dispose();

                    Thumb.Dispose();
                    Thumb = null;

                    kbyte = 20;
                }

                img.Dispose();
                img = null;
            }
            catch (Exception ex)
            {
                LogTools.Write(null, ex, "ImageTools.SaveFromBase64");
            }

            if (IsImage && (kbyte <= 20))
            {
                object obj = new object();
                lock (obj)
                {
                    if (!File.Exists(Config.PictureFolder + name))
                        File.WriteAllText(Config.PictureFolder + name, b64);
                    result = true;
                }
            }
            return result;
        }

        public static bool SaveFromByteArray(byte[] buffer, out string name)
        {
            bool result = false;
            string b64 = "";
            name = NetTalk.Common.Hash.NetTalkHash.HashData(buffer, "sha1");
            bool IsImage = false;
            float kbyte = Convert.ToSingle(buffer.Length) / 1024f;
            try
            {
                MemoryStream st = new MemoryStream();
                st.Write(buffer, 0, buffer.Length);
                Image img = Image.FromStream(st);
                st.Close();
                st.Dispose();
                IsImage = true;
                if (kbyte > 20)
                {
                    Image Thumb = NetTalk.Common.ImageTools.NetTalkCropImage.Thumbnail(img, true, 150);
                    st = new MemoryStream();
                    Thumb.Save(st, NetTalk.Common.ImageTools.NetTalkEncoder.JpegEncoderInfo, NetTalk.Common.ImageTools.NetTalkEncoder.EncoderParams(85));

                    buffer = st.ToArray();
                    b64 = Convert.ToBase64String(buffer);

                    st.Close();
                    st.Dispose();

                    Thumb.Dispose();
                    Thumb = null;

                    kbyte = 20;
                }

                img.Dispose();
                img = null;
            }
            catch (Exception ex)
            {
                LogTools.Write(null, ex, "ImageTools.SaveFromByteArray");
            }

            if (IsImage && (kbyte <= 20))
            {
                object obj = new object();
                lock (obj)
                {
                    if (!File.Exists(Config.PictureFolder + name))
                        File.WriteAllText(Config.PictureFolder + name, b64);
                    result = true;
                }
            }
            return result;
        }
    }
}