using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NetTalk.Common.ImageTools
{
    public class NetTalkThumb: IHttpHandler
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string url = context.Server.UrlDecode(context.Request.QueryString["url"]);
            url = context.Server.MapPath("~/" + url);
            if (System.IO.File.Exists(url))
            {
                int width = 200, height = 150;
                byte quality = 85;

                if (!string.IsNullOrEmpty(context.Request.QueryString["w"]))
                    width = Convert.ToInt32(context.Request.QueryString["w"]);
                if (!string.IsNullOrEmpty(context.Request.QueryString["h"]))
                    height = Convert.ToInt32(context.Request.QueryString["h"]);
                if (!string.IsNullOrEmpty(context.Request.QueryString["q"]))
                    quality = Convert.ToByte(context.Request.QueryString["q"]);

                string fname = System.IO.Path.GetFileName(url);
                context.Response.ContentType = "image/jpeg";
                context.Response.AddHeader("Content-Disposition", "filename=\"" + quality.ToString() + "_" + width.ToString() + "_" + height.ToString() + "_" + fname + "\"");
                DateTime lastMod = System.IO.File.GetLastWriteTimeUtc(url);
                context.Response.AddHeader("Last-Modified", lastMod.ToString("R"));
                if (context.Request.Headers["If-Modified-Since"] != null)
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(context.Request.Headers["If-Modified-Since"]);
                        if (lastMod <= dt)
                        {
                            context.Response.StatusCode = 304;
                            context.Response.StatusDescription = "Not Modified";
                            context.Response.End();
                            return;
                        }
                    }
                    catch { context.Response.AddHeader("If-Modified-Since", lastMod.ToString("R")); }
                }
                else
                {
                    context.Response.AddHeader("If-Modified-Since", lastMod.ToString("R"));
                }

                Image img = Image.FromFile(url);
                Image thumb = null;

                if (context.Request.QueryString["mode"] == "full")
                    thumb = NetTalkCropImage.Full(img, width, height);
                else if (context.Request.QueryString["mode"] == "thumb")
                    thumb = NetTalkCropImage.Thumbnail(img, true, width);
                else
                    thumb = NetTalkCropImage.Crop(img, width, height);
                    

                thumb.Save(context.Response.OutputStream, NetTalkEncoder.JpegEncoderInfo, NetTalkEncoder.EncoderParams(quality));
                thumb.Dispose();
                thumb = null;
                img.Dispose();
                img = null;
            }
            context.Response.End();
        }

        #endregion
    }
}
