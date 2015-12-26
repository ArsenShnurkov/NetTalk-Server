using System;

using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace NetTalk.Common.ImageTools
{
    public class NetTalkCropImage
    {
        public static Bitmap Thumbnail(Image SourceImg, bool IsWidthBase, int Value)
        {
            SizeF NewImageSize = new SizeF();
            if (IsWidthBase)
            {
                NewImageSize.Height = (float)(Value * SourceImg.Height) / (float)SourceImg.Width;
                NewImageSize.Width = Value;
            }
            else
            {
                NewImageSize.Width = (float)(Value * SourceImg.Width) / (float)SourceImg.Height;
                NewImageSize.Height = Value;
            }

            Bitmap Thumb = new Bitmap(Convert.ToInt32(NewImageSize.Width), Convert.ToInt32(NewImageSize.Height));
            Graphics g = Graphics.FromImage(Thumb);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(SourceImg, 0, 0, Thumb.Width, Thumb.Height);
            g.Dispose();
            g = null;

            return Thumb;
        }

        public static Bitmap Crop(Image SourceImg, int Width, int Height)
        {
            Graphics g;
            float WFactor, HFactor;
            WFactor = Convert.ToSingle(SourceImg.Width) / Convert.ToSingle(Width);
            HFactor = Convert.ToSingle(SourceImg.Height) / Convert.ToSingle(Height);

            Rectangle Box = new Rectangle(0, 0, Width, Height);
            int h, w;
            h = 0;
            w = 0;
            if (WFactor <= HFactor)
            {
                h = Convert.ToInt32((Convert.ToSingle(Height) * WFactor));
                Box.Y = ((SourceImg.Height - h) / 2);
                Box.Width = SourceImg.Width;
                Box.Height = h;
            }
            else
            {
                w = Convert.ToInt32((Convert.ToSingle(Width) * HFactor));
                Box.X = ((SourceImg.Width - w) / 2);
                Box.Height = SourceImg.Height;
                Box.Width = w;
            }
            Bitmap Cropped = new Bitmap(Width, Height);
            g = Graphics.FromImage(Cropped);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(SourceImg, new Rectangle(0, 0, Width, Height), Box, GraphicsUnit.Pixel);

            g.Dispose();
            g = null;

            return Cropped;
        }

        public static Bitmap Crop(Image SourceImg)
        {
            return Crop(SourceImg, 200, 150);
        }

        private static Bitmap Full(Image SourceImg, int Width, int Height, Brush BackColor, Color? FrameColor, float? FrameSize)
        {   
            float WFactor, HFactor;
            WFactor = Convert.ToSingle(SourceImg.Width) / Convert.ToSingle(Width);
            HFactor = Convert.ToSingle(SourceImg.Height) / Convert.ToSingle(Height);

            Size NewSize = new Size();
            Point StartPoint = new Point();

            if (WFactor >= HFactor)
            {
                NewSize.Width = Width;
                NewSize.Height = Convert.ToInt32((Convert.ToSingle(SourceImg.Height) / WFactor));
                StartPoint.X = 0;
                StartPoint.Y = (Height - NewSize.Height) / 2;
            }
            else
            {
                NewSize.Height = Height;
                NewSize.Width = Convert.ToInt32((Convert.ToSingle(SourceImg.Width) / HFactor));
                StartPoint.Y = 0;
                StartPoint.X = (Width - NewSize.Width) / 2;
            }
            Bitmap Result = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(Result);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRectangle(BackColor, 0, 0, Width, Height);
            g.DrawImage(SourceImg, StartPoint.X, StartPoint.Y, NewSize.Width, NewSize.Height);

            if (FrameColor.HasValue && FrameSize.HasValue)
            {
                Pen p = new Pen(FrameColor.Value, FrameSize.Value);
                float nim = FrameSize.Value / 2.0f;
                nim -= 1;
                if (FrameSize.Value == 1.0f)
                {   
                    g.DrawRectangle(p, nim, nim, ((Convert.ToSingle(Width) - FrameSize.Value) - nim), ((Convert.ToSingle(Height) - FrameSize.Value) - nim));
                }
                else
                {
                    g.DrawRectangle(p, nim, nim, (Convert.ToSingle(Width) - FrameSize.Value) + 1, (Convert.ToSingle(Height) - FrameSize.Value) + 1);
                }
            }
            g.Dispose();
            g = null;
            return Result;
        }

        public static Bitmap Full(Image SourceImg, int Width, int Height)
        {
            Color? C = null;
            float? S = null;
            return Full(SourceImg, Width, Height, Brushes.White, C, S);
        }

        public static Bitmap Full(Image SourceImg, int Width, int Height, Brush BackColor)
        {
            Color? C = null;
            float? S = null;
            return Full(SourceImg, Width, Height, BackColor, C, S);
        }

        public static Bitmap Full(Image SourceImg, int Width, int Height, Brush BackColor, Color FrameColor, float FrameSize)
        {
            Color? C = FrameColor;
            float? S = FrameSize;
            return Full(SourceImg, Width, Height, BackColor, C, S);
        }
    }
}
