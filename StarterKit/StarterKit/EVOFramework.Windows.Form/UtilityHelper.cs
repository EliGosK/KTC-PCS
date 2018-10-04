using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using EVOFramework.Windows.Forms;
using System.Windows.Forms;

namespace EVOFramework
{
    public class ImageHelper
    {
        /// <summary>
        /// Get thumbnail image.
        /// </summary>
        /// <param name="img">Original image.</param>
        /// <param name="width">adjust width size.</param>
        /// <param name="height">adjust height size.</param>
        /// <returns></returns>
        public static Image GetThumbnailImage(Image img, int width, int height)
        {

            Image thumb = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(thumb))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.DrawImage(img, 0, 0, width, height);
            }

            return thumb;            
        }

        /// <summary>
        /// Resize image.
        /// </summary>
        /// <param name="img"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image ResizeImage(Image img, int width, int height) {            
            Image newImage = img.GetThumbnailImage(width, height, null, IntPtr.Zero);
            return newImage;
        }

        /// <summary>
        /// Convert ByteArray (byte[]) to Image object.
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public Image ConvertByteArrayToImage(byte[] byteArray) {

            MemoryStream mem = new MemoryStream(byteArray);
            mem.Position = 0;
            Image image = Image.FromStream(mem);
            mem.Close();
            mem.Dispose();

            return image;
        }

        /// <summary>
        /// Convert Image object to ByteArray (byte[])
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public byte[] ConvertImageToByteArray(Image image) {
            byte[] byteArray = null;
            using (MemoryStream mem = new MemoryStream()) {
                image.Save(mem, ImageFormat.Png);
                byteArray = mem.ToArray();
            }

            return byteArray;
        }
    }

    /// <summary>
    /// Provides Round-trip conversion from RGB to HSB and back
    /// </summary>
    public struct ColorHelper
    {
        float h;
        float s;
        float b;
        int a;

        public ColorHelper(float h, float s, float b)
        {
            this.a = 0xff;
            this.h = Math.Min(Math.Max(h, 0), 255);
            this.s = Math.Min(Math.Max(s, 0), 255);
            this.b = Math.Min(Math.Max(b, 0), 255);
        }

        public ColorHelper(int a, float h, float s, float b)
        {
            this.a = a;
            this.h = Math.Min(Math.Max(h, 0), 255);
            this.s = Math.Min(Math.Max(s, 0), 255);
            this.b = Math.Min(Math.Max(b, 0), 255);
        }

        public ColorHelper(Color color)
        {
            ColorHelper temp = FromColor(color);
            this.a = temp.a;
            this.h = temp.h;
            this.s = temp.s;
            this.b = temp.b;
        }

        public float H
        {
            get { return h; }
        }

        public float S
        {
            get { return s; }
        }

        public float B
        {
            get { return b; }
        }

        public int A
        {
            get { return a; }
        }

        public Color Color
        {
            get
            {
                return FromHSB(this);
            }
        }

        public static Color ShiftHue(Color c, float hueDelta)
        {
            ColorHelper hsb = ColorHelper.FromColor(c);
            hsb.h += hueDelta;
            hsb.h = Math.Min(Math.Max(hsb.h, 0), 255);
            return FromHSB(hsb);
        }

        public static Color ShiftSaturation(Color c, float saturationDelta)
        {
            ColorHelper hsb = ColorHelper.FromColor(c);
            hsb.s += saturationDelta;
            hsb.s = Math.Min(Math.Max(hsb.s, 0), 255);
            return FromHSB(hsb);
        }


        public static Color ShiftBrighness(Color c, float brightnessDelta)
        {
            ColorHelper hsb = ColorHelper.FromColor(c);
            hsb.b += brightnessDelta;
            hsb.b = Math.Min(Math.Max(hsb.b, 0), 255);
            return FromHSB(hsb);
        }

        public static Color FromHSB(ColorHelper hsbColor)
        {
            float r = hsbColor.b;
            float g = hsbColor.b;
            float b = hsbColor.b;
            if (hsbColor.s != 0)
            {
                float max = hsbColor.b;
                float dif = hsbColor.b * hsbColor.s / 255f;
                float min = hsbColor.b - dif;

                float h = hsbColor.h * 360f / 255f;

                if (h < 60f)
                {
                    r = max;
                    g = h * dif / 60f + min;
                    b = min;
                }
                else if (h < 120f)
                {
                    r = -(h - 120f) * dif / 60f + min;
                    g = max;
                    b = min;
                }
                else if (h < 180f)
                {
                    r = min;
                    g = max;
                    b = (h - 120f) * dif / 60f + min;
                }
                else if (h < 240f)
                {
                    r = min;
                    g = -(h - 240f) * dif / 60f + min;
                    b = max;
                }
                else if (h < 300f)
                {
                    r = (h - 240f) * dif / 60f + min;
                    g = min;
                    b = max;
                }
                else if (h <= 360f)
                {
                    r = max;
                    g = min;
                    b = -(h - 360f) * dif / 60 + min;
                }
                else
                {
                    r = 0;
                    g = 0;
                    b = 0;
                }
            }

            return Color.FromArgb
                (
                    hsbColor.a,
                    (int)Math.Round(Math.Min(Math.Max(r, 0), 255)),
                    (int)Math.Round(Math.Min(Math.Max(g, 0), 255)),
                    (int)Math.Round(Math.Min(Math.Max(b, 0), 255))
                    );
        }

        public static ColorHelper FromColor(Color color)
        {
            ColorHelper ret = new ColorHelper(0f, 0f, 0f);
            ret.a = color.A;

            float r = color.R;
            float g = color.G;
            float b = color.B;

            float max = Math.Max(r, Math.Max(g, b));

            if (max <= 0)
            {
                return ret;
            }

            float min = Math.Min(r, Math.Min(g, b));
            float dif = max - min;

            if (max > min)
            {
                if (g == max)
                {
                    ret.h = (b - r) / dif * 60f + 120f;
                }
                else if (b == max)
                {
                    ret.h = (r - g) / dif * 60f + 240f;
                }
                else if (b > g)
                {
                    ret.h = (g - b) / dif * 60f + 360f;
                }
                else
                {
                    ret.h = (g - b) / dif * 60f;
                }
                if (ret.h < 0)
                {
                    ret.h = ret.h + 360f;
                }
            }
            else
            {
                ret.h = 0;
            }

            ret.h *= 255f / 360f;
            ret.s = (dif / max) * 255f;
            ret.b = max;

            return ret;
        }
    }

    internal class FormHelper {
        /// <summary>
        /// Find backtrack to form host of given control.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static EVOForm FindEVOForm(Control control) {
            if (control == null)
                return null;

            if (control is EVOForm)
                return (EVOForm)control;

            return FindEVOForm(control.Parent);
        }
    }
}
