using System;
using System.Collections.Generic;
using System.Linq;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace NetTalk.Common.ImageTools
{
    public class NetTalkEncoder
    {
        public static ImageCodecInfo EncoderInfo(string mimeType)
        {
            int index;
            ImageCodecInfo result = null;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (index = 0; index < encoders.Length; index++)
            {
                if (encoders[index].MimeType == mimeType)
                {
                    result = encoders[index];
                    break;
                }
            }
            return result;
        }

        public static EncoderParameters EncoderParams(byte ImageQuality)
        {
            EncoderParameters enc = new EncoderParameters(1);
            enc.Param[0] = new EncoderParameter(Encoder.Quality, Convert.ToInt64(ImageQuality));
            return enc;
        }

        public static ImageCodecInfo JpegEncoderInfo
        {
            get
            {
                return EncoderInfo("image/jpeg");
            }
        }
    }
}
