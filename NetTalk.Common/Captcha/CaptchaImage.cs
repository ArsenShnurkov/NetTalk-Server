using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace NetTalk.Common.Captcha
{
    public class NetTalkCaptchaImage
    {
        // Public properties (all read-only).
        public string Text
        {
            get { return this.text; }
        }
        public Bitmap Image
        {
            get { return this.image; }
        }
        public int Width
        {
            get { return this.width; }
        }
        public int Height
        {
            get { return this.height; }
        }
        public Color BackgroundColor
        {
            get { return this.bgColor; }
            //set { this.bgColor = value; }
        }
        public Color ForeColor
        {
            get { return this.foreColor; }
            //set { this.foreColor = value; }
        }

        /*public int FontSize
        {
            get { return this.fontSize; }
            set { this.fontSize = value; }
        }*/


        // Internal properties.
        private string text;
        private int width;
        private int height;
        private string familyName;
        private Bitmap image;

        private Color bgColor = Color.FromArgb(211, 211, 211);
        private Color foreColor = Color.FromArgb(66, 33, 00);
        //private int fontSize = 0;

        // For generating random numbers.
        private Random random = new Random();

        // ====================================================================
        // Initializes a new instance of the CaptchaImage class using the
        // specified text, width and height.
        // ====================================================================
        public NetTalkCaptchaImage(string s, int width, int height)
        {
            this.text = s;
            this.SetDimensions(width, height);
            this.GenerateImage();
        }

        // ====================================================================
        // Initializes a new instance of the CaptchaImage class using the
        // specified text, width, height and font family.
        // ====================================================================
        public NetTalkCaptchaImage(string s, int width, int height, string familyName)
        {
            this.text = s;
            this.SetDimensions(width, height);
            this.SetFamilyName(familyName);
            this.GenerateImage();
        }

        // ====================================================================
        // Initializes a new instance of the CaptchaImage class using the
        // specified text, width, height, font family, ForeColor and BackgroundColor.
        // ====================================================================
        public NetTalkCaptchaImage(string s, int width, int height, string familyName, Color foreColor, Color backgroundColor)
        {
            this.text = s;
            this.SetDimensions(width, height);
            this.SetFamilyName(familyName);
            this.foreColor = foreColor;
            this.bgColor = backgroundColor;

            this.GenerateImage();
        }

        // ====================================================================
        // This member overrides Object.Finalize.
        // ====================================================================
        ~NetTalkCaptchaImage()
        {
            Dispose(false);
        }

        // ====================================================================
        // Releases all resources used by this object.
        // ====================================================================
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        // ====================================================================
        // Custom Dispose method to clean up unmanaged resources.
        // ====================================================================
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                // Dispose of the bitmap.
                this.image.Dispose();
        }

        // ====================================================================
        // Sets the image width and height.
        // ====================================================================
        private void SetDimensions(int width, int height)
        {
            // Check the width and height.
            if (width <= 0)
                throw new ArgumentOutOfRangeException("width", width, "Argument out of range, must be greater than zero.");
            if (height <= 0)
                throw new ArgumentOutOfRangeException("height", height, "Argument out of range, must be greater than zero.");
            this.width = width;
            this.height = height;
        }

        // ====================================================================
        // Sets the font used for the image text.
        // ====================================================================
        private void SetFamilyName(string familyName)
        {
            // If the named font is not installed, default to a system font.
            try
            {
                if (familyName != null)
                {
                    Font font = new Font(this.familyName, 12F);
                    this.familyName = familyName;
                    font.Dispose();
                }
                else
                {
                    this.familyName = System.Drawing.FontFamily.GenericSerif.Name;
                }
            }
            catch
            {
                this.familyName = System.Drawing.FontFamily.GenericSerif.Name;
            }
        }

        // ====================================================================
        // Creates the bitmap image.
        // ====================================================================
        private void GenerateImage()
        {
            // Create a new 32-bit bitmap image.
            Bitmap bitmap = new Bitmap(this.width, this.height, PixelFormat.Format32bppArgb);

            // Create a graphics object for drawing.
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, this.width, this.height);

            // CHANGE THE BACKGROUND COLORS HERE.
            Color clrb1 = this.BackgroundColor;
            Color clrb2 = this.BackgroundColor;

            //HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.White);
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, clrb1, clrb2);
            g.FillRectangle(hatchBrush, rect);

            // Set up the text font.
            SizeF size;
            float fontSize = rect.Height + 1;
            Font font;
            // Adjust the font size until the text fits within the image.
            do
            {
                fontSize--;
                font = new Font(this.familyName, fontSize, FontStyle.Bold);
                size = g.MeasureString(this.text, font);
            } while (size.Width > rect.Width);

            // Set up the text format.
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            // Create a path using the text and warp it randomly.
            GraphicsPath path = new GraphicsPath();
            path.AddString(this.text, font.FontFamily, (int)font.Style, font.Size, rect, format);
            float v = 4F;
            PointF[] points =
			{
				new PointF(this.random.Next(rect.Width) / v, this.random.Next(rect.Height) / v),
				new PointF(rect.Width - this.random.Next(rect.Width) / v, this.random.Next(rect.Height) / v),
				new PointF(this.random.Next(rect.Width) / v, rect.Height - this.random.Next(rect.Height) / v),
				new PointF(rect.Width - this.random.Next(rect.Width) / v, rect.Height - this.random.Next(rect.Height) / v)
			};
            Matrix matrix = new Matrix();
            matrix.Translate(0F, 0F);
            path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);

            //CHANGE THE TEXT COLORS HERE
            Color clrt1 = this.ForeColor;
            Color clrt2 = this.ForeColor;


            //hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.LightGray, Color.DarkGray);
            hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, clrt1, clrt2);
            g.FillPath(hatchBrush, path);

            // Add some random noise.
            int m = Math.Max(rect.Width, rect.Height);
            for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
            {
                int x = this.random.Next(rect.Width);
                int y = this.random.Next(rect.Height);
                int w = this.random.Next(m / 50);
                int h = this.random.Next(m / 50);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }

            // Clean up.
            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();

            // Set the image.
            this.image = bitmap;
        }

        public static string RandomCode(CaptchaType ctype, int numberOfChars)
        {
            string s = "";
            string alphas = "ABCDEFGHIJKLMNPQRSTUVWXYZ"; //if you want to add other charaters add it here - zero and O are removed to avoid confusion
            string alphanumeric = "123456789ABCDEFGHIJKLMNPQRSTUVWXYZ";
            Random rnd = new Random();

            for (int i = 0; i < numberOfChars; i++)
            {
                if (ctype == CaptchaType.Numeric)
                {
                    s = String.Concat(s, rnd.Next(10).ToString());
                }
                else if (ctype == CaptchaType.Alpha)
                {
                    s = String.Concat(s, alphas.Substring(rnd.Next(24), 1));
                }
                else
                {
                    s = String.Concat(s, alphanumeric.Substring(rnd.Next(33), 1));
                }

            }
            return s;
        }
    }

    public enum CaptchaType
    {
        Numeric = 1, Alpha = 2, AlphaNumeric = 3
    }
}
