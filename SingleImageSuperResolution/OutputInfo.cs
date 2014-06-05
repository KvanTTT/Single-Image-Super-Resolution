
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SingleImageSuperResolution
{
    public struct OutputInfo
    {
        public Bitmap Image;
        public double MinDistance;
        public double MaxDistance;
        public double AvgDistance;
    }
}
