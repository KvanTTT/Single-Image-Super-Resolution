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

        public LevelImageFragment(byte[] rgb, byte[] yComponents, int imageWidth, int imageHeight, double xOffset, double yOffset, int width, int height)
        {
            Offset = new PointD(xOffset / imageWidth, yOffset / imageHeight);
            YComponents = new byte[width * height];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    int srcInd = (int)Math.Round((int)Math.Round(yOffset + i) * imageWidth + (xOffset + j));
                    int dstInd = i * width + j;
                    YComponents[dstInd] = yComponents[srcInd];
                }
        }
    }
}
