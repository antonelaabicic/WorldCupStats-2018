using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class GenderItem
    {
        public Gender GenderValue { get; set; }
        public string DisplayText { get; set; }

        public GenderItem (Gender gender, string displayText)
        {
            GenderValue = gender;
            DisplayText = displayText;
        }

        public override string ToString() { return DisplayText; }
    }
}
