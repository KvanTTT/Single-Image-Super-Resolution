using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SingleImageSuperResolution
{
    public class Utils
    {
        const int RedOffset = 2;
        const int GreenOffset = 1;
        const int BlueOffset = 0;
        const int AlphaOffset = 3;
        const int ComponentsCount = 4;

        public static byte[] BitmapToBytesArray(Bitmap bitmap)
        {
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bytesCount = bitmap.Width * bitmap.Height * ComponentsCount;
            byte[] byteData = new byte[bytesCount];
            IntPtr ptr = bmpData.Scan0;
            Marshal.Copy(ptr, byteData, 0, bytesCount);
            bitmap.UnlockBits(bmpData);

            return byteData;
        }

        public static byte[] ARGBtoY(byte[] argb) // YIQ
        {
            int length = argb.Length / ComponentsCount;
            byte[] result = new byte[length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (byte)Math.Round(
                    argb[i * ComponentsCount + RedOffset] * 0.299 +
                    argb[i * ComponentsCount + GreenOffset] * 0.587 +
                    argb[i * ComponentsCount + BlueOffset] * 0.114);
            }

            return result;
        }
    }
}
