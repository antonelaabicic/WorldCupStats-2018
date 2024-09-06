using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchView.Events
{
    public class PlayerDataEventArgs : EventArgs
    {
        public Player Player { get; }

        public PlayerDataEventArgs(Player player)
        {
            Player = player;
        }
    }
}
