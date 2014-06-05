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

        public byte[] YComps
        {
            get;
            set;
        }

        public List<LevelImageFragment> Fragments
        {
            get;
            set;
        }
        public LevelImage(Bitmap bitmap, int newWidht, int newHeight)
            : this(Utils.ChangeSize(bitmap, newWidht, newHeight))
        {
        }

        public LevelImage(Bitmap bitmap)
        {
            Image = bitmap;
            RGB = Utils.BitmapToBytesArray(bitmap);
            YComps = Utils.ARGBtoY(RGB);
        }

        public void PrepareFragments(double incX = 1, double incY = 1, int blockWidth = 9, int blockHeight = 9)
        {
            var xStepsCount = (int)((Image.Width - blockWidth) / incX);
            var yStepsCount = (int)((Image.Height - blockHeight) / incY);
            Fragments = new List<LevelImageFragment>();
            for (int j = 0; j < yStepsCount; j++)
                for (int i = 0; i < xStepsCount; i++)
                {
                    Fragments.Add(new LevelImageFragment(RGB, YComps, Image.Width, Image.Height, i * incX, j * incY, blockWidth, blockHeight));
                }
        }

        public double[] FragmentYCompsToDoubleArray()
        {
            var result = new double[Fragments.Count * Fragments[0].YComponents.Length];
            for (int i = 0; i < Fragments.Count; i++)
            {
                var yComponents = Fragments[i].YComponents;
                for (int j = 0; j < yComponents.Length; j++)
                    result[i * yComponents.Length + j] = yComponents[j];
            }
            return result;
        }
    }
}
