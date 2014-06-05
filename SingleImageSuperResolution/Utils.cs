using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SingleImageSuperResolution
{
    public class Utils
    {
        public const int RedOffset = 2;
        public const int GreenOffset = 1;
        public const int BlueOffset = 0;
        public const int AlphaOffset = 3;
        public const int ColorComponentsCount = 4;

        public static byte[] BitmapToBytesArray(Bitmap bitmap)
        {
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bytesCount = bitmap.Width * bitmap.Height * ColorComponentsCount;
            byte[] byteData = new byte[bytesCount];
            IntPtr ptr = bmpData.Scan0;
            Marshal.Copy(ptr, byteData, 0, bytesCount);
            bitmap.UnlockBits(bmpData);

            return byteData;
        }

        public static Bitmap BytesArrayToBitmap(byte[] array, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            BitmapData bmData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
            IntPtr pNative = bmData.Scan0;
            Marshal.Copy(array, 0, pNative, width * height * ColorComponentsCount);
            bitmap.UnlockBits(bmData);
            return bitmap;
        }

        public static byte[] ARGBtoY(byte[] argb) // YIQ
        {
            int length = argb.Length / ColorComponentsCount;
            byte[] result = new byte[length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (byte)Math.Round(
                    argb[i * ColorComponentsCount + RedOffset] * 0.299 +
                    argb[i * ColorComponentsCount + GreenOffset] * 0.587 +
                    argb[i * ColorComponentsCount + BlueOffset] * 0.114);
            }

            return result;
        }

        public static Bitmap ChangeSize(Bitmap bitmap, int newWidth, int newHeight, InterpolationMode interpolationMode = InterpolationMode.High)
        {
            var result = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CompositingQuality =  CompositingQuality.HighQuality;
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.InterpolationMode = interpolationMode;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(bitmap, 0, 0, newWidth, newHeight);
            }
            return result;
        }
    }
}
