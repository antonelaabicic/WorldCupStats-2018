using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ScreenSizeItem
    {
        public ScreenSize ScreenSizeValue { get; set; }
        public string DisplayText { get; set; }

        public ScreenSizeItem(ScreenSize screenSize, string displayText)
        {
            ScreenSizeValue = screenSize;
            DisplayText = displayText;
        }

        public override string ToString() { return DisplayText; }
    }
}
