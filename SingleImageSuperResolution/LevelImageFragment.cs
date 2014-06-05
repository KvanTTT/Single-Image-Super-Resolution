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
        public PointD Offset;
        public byte[] YComponents;

        public LevelImageFragment(byte[] yComponents, int imageWidth, int imageHeight, int xOffset, int yOffset, int width, int height)
        {
            Offset = new PointD((double)xOffset / imageWidth, (double)yOffset / imageHeight);
            YComponents = new byte[width * height];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    YComponents[i * width + j] = yComponents[(yOffset + i) * imageWidth + (xOffset + j)];
        }
    }
}
