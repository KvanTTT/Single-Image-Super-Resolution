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
        public const int BlurOffset = 0;
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

        public static byte[] ARGBtoY(Bitmap bitmap)
        {
            return ARGBtoY(BitmapToBytesArray(bitmap));
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
                    argb[i * ColorComponentsCount + BlurOffset] * 0.114);
            }

            return result;
        }

        public static Bitmap ChangeSize(Bitmap bitmap, int newWidth, int newHeight, InterpolationMode interpolationMode = InterpolationMode.High)
        {
            var result = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.InterpolationMode = interpolationMode;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(bitmap, 0, 0, newWidth, newHeight);
            }
            return result;
        }

        public static Bitmap GaussianBlur(Bitmap bitmap, int size, double sigma)
        {
            return BytesArrayToBitmap(GaussianBlur(ARGBtoY(bitmap), bitmap.Width, bitmap.Height, size, sigma), bitmap.Width, bitmap.Height);
        }

        public static byte[] GaussianBlur(byte[] grayscaled, int width, int height, int size, double sigma)
        {
            int i, j;

            double[] doubleKernel = GaussKernel2D(size, sigma);
            double min = doubleKernel[0];

            int[] kernel = new int[size * size];
            int divisor = 0;

            for (i = 0; i < size; i++)
            {
                int i_size = i * size;
                for (j = 0; j < size; j++)
                {
                    double v = doubleKernel[i_size + j] / min;

                    if (v > 65535)
                        v = 65535;
                    kernel[i_size + j] = (int)v;

                    divisor += kernel[i_size + j];
                }
            }

            byte[] dst = new byte[grayscaled.Length];

            int threshold = 0;

            int srcInd = 0;
            int t, k, ir, jr;
            int radius = size >> 1;
            long g, div;

            int kernelSize = size * size;
            int processedKernelSize;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++, srcInd++)
                {
                    g = div = processedKernelSize = 0;

                    for (i = 0; i < size; i++)
                    {
                        ir = i - radius;
                        t = y + ir;

                        if (t < 0)
                            continue;
                        if (t >= height)
                            break;

                        int i_size = i * size;
                        int ir_width = ir * width;

                        for (j = 0; j < size; j++)
                        {
                            jr = j - radius;
                            t = x + jr;

                            if (t < 0)
                                continue;

                            if (t < width)
                            {
                                k = kernel[i_size + j];
                                div += k;
                                g += k * grayscaled[srcInd + ir_width + jr];
                                processedKernelSize++;
                            }
                        }
                    }

                    if (processedKernelSize == kernelSize)
                    {
                        div = divisor;
                    }

                    if (div != 0)
                        g /= div;
                    g += threshold;

                    dst[srcInd] = (byte)((g > 255) ? 255 : ((g < 0) ? 0 : g));
                }
            }

            return dst;
        }

        public static double[] GaussKernel2D(int size, double sigma)
        {
            // raduis
            int r = size / 2;
            // kernel
            double[] kernel = new double[size * size];

            // compute kernel
            double sqrSigma = sigma * sigma;
            double c1 = 1 / (-2 * sqrSigma);
            double c2 = 1 / (2 * Math.PI * sqrSigma);
            for (int y = -r, i = 0; i < size; y++, i++)
            {
                int y2 = y * y;
                int i_size = i * size;
                for (int x = -r, j = 0; j < size; x++, j++)
                    kernel[i_size + j] = Math.Exp((x * x + y2) * c1) * c2;
            }

            return kernel;
        }
    }
}