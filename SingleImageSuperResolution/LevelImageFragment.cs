using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleImageSuperResolution
{
    public class LevelImageFragment
    {
        public PointD Offset
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public int Size
        {
            get
            {
                return Width * Height;
            }
        }

        public LevelImageFragment(byte[] rgb, byte[] yComponents, int imageWidth, int imageHeight, double xOffset, double yOffset, int width, int height)
        {
            Offset = new PointD(xOffset / imageWidth, yOffset / imageHeight);
            Width = width;
            Height = height;
        }
    }
}
