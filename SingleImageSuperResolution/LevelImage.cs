using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleImageSuperResolution
{
    public class LevelImage
    {
        public Bitmap Image
        {
            get;
            set;
        }

        public byte[] RGB
        {
            get;
            set;
        }

        public byte[] Components
        {
            get;
            set;
        }

        public List<LevelImageFragment> Fragments
        {
            get;
            set;
        }

        public LevelImage(Bitmap bitmap, int newWidht, int newHeight, bool blur, int blurKernelSize, double blurSigma)
            : this(Utils.ChangeSize(bitmap, newWidht, newHeight), blur, blurKernelSize, blurSigma)
        {
        }

        public LevelImage(Bitmap bitmap, bool blur, int blurKernelSize, double blurSigma)
        {
            Image = bitmap;
            RGB = Utils.BitmapToBytesArray(bitmap);
            Components = Utils.ARGBtoY(RGB);
            if (blur)
                Components = Utils.GaussianBlur(Components, Image.Width, Image.Height, blurKernelSize, blurSigma);
        }

        public void PrepareFragments(bool blur = false, double incX = 1, double incY = 1, int blockWidth = 9, int blockHeight = 9)
        {
            var xStepsCount = (int)((Image.Width - blockWidth) / incX);
            var yStepsCount = (int)((Image.Height - blockHeight) / incY);
            Fragments = new List<LevelImageFragment>();
            for (int j = 0; j < yStepsCount; j++)
                for (int i = 0; i < xStepsCount; i++)
                    Fragments.Add(new LevelImageFragment(RGB, Components, Image.Width, Image.Height, i * incX, j * incY, blockWidth, blockHeight));
        }

        public double[] FragmentYCompsToDoubleArray(int ind)
        {
            return FragmentYCompsToDoubleArray(ind, ind + 1);
        }

        public double[] FragmentYCompsToDoubleArray()
        {
            return FragmentYCompsToDoubleArray(0, Fragments.Count);
        }

        public double[] FragmentYCompsToDoubleArray(int startInd, int endInd)
        {
            if (Fragments.Count == 0)
                return new double[0];

            var result = new double[(endInd - startInd) * Fragments[0].Size];
            int dstInd = 0;
            int fragmentWidth = Fragments[0].Width;
            int fragmentHeight = Fragments[0].Height;
            for (int i = startInd; i < endInd; i++)
            {
                var fragment = Fragments[i];
                var offset = fragment.Offset;
                for (int j = 0; j < fragmentHeight; j++)
                {
                    int y = (int)Math.Round(offset.Y * Image.Height + j) * Image.Width;
                    for (int k = 0; k < fragmentWidth; k++)
                        result[dstInd++] = Components[(int)Math.Round(y + (offset.X * Image.Width + k))];
                }
            }

            return result;
        }
    }
}
