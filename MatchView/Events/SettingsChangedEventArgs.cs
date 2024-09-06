using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchView.Events
{
    public class SettingsChangedEventArgs : EventArgs
    {
        public string Language { get; }
        public Gender Championship { get; }
        public ScreenSize ScreenSize { get; }

        public SettingsChangedEventArgs(string language, Gender championship, ScreenSize screenSize)
        {
            Language = language;
            Championship = championship;
            ScreenSize = screenSize;
        }
    }
}
