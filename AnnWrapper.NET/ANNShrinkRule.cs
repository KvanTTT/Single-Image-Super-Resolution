using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnWrapperNET
{
    public enum ANNShrinkRule
    {
        ANN_BD_NONE = 0, // no shrinking at all (just kd-tree)
        ANN_BD_SIMPLE = 1, // simple splitting
        ANN_BD_CENTROID = 2, // centroid splitting
        ANN_BD_SUGGEST = 3 // the authors' suggestion for best
    }
}
