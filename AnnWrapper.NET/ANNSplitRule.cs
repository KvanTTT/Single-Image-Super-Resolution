using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnWrapperNET
{
    public enum ANNSplitRule
    {
        ANN_KD_STD = 0, // the optimized kd-splitting rule
        ANN_KD_MIDPT = 1, // midpoint split
        ANN_KD_FAIR = 2, // fair split
        ANN_KD_SL_MIDPT = 3, // sliding midpoint splitting method
        ANN_KD_SL_FAIR = 4, // sliding fair split method
        ANN_KD_SUGGEST = 5 // the authors' suggestion for best
    }
}
