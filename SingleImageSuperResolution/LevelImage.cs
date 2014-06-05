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

        public byte[] Pixels
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
            : this(new Bitmap(bitmap, newWidht, newHeight))
        {
        }

        public LevelImage(Bitmap bitmap)
        {
            Image = bitmap;
            Pixels = Utils.BitmapToBytesArray(bitmap);
            YComps = Utils.ARGBtoY(Pixels);
        }

        public void PrepareFragments(int incX = 1, int incY = 1, int blockWidth = 9, int blockHeight = 9)
        {
            Fragments = new List<LevelImageFragment>();
            for (int j = 0; j < Image.Height - blockHeight; j += incY)
                for (int i = 0; i < Image.Width - blockWidth; i += incX)
                {
                    Fragments.Add(new LevelImageFragment(YComps, Image.Width, Image.Height, i, j, blockWidth, blockHeight));
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
