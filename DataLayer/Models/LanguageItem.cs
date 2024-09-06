using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class LanguageItem
    {
        public string Text { get; set; } = null!;
        public object Tag { get; set; } = null!;

        public override string ToString()
        {
            return Text;
        }
    }
}
