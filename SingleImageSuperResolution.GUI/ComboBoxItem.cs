using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingleImageSuperResolution.GUI
{
    public class ComboBoxItem
    {
        public object Value
        {
            get;
            set;
        }

        public string Caption
        {
            get;
            set;
        }

        public ComboBoxItem(object value, string caption)
        {
            Value = value;
            Caption = caption;
        }

        public override string ToString()
        {
            return Caption;
        }
    }
}
