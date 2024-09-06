using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPro.Events
{
    public class SettingsEventArgs : EventArgs
    {
        public string Language { get; set; } = null!;
        public Gender Championship { get; set; }
    }
}
