using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPro.Events
{
    public class FavPlayersEventArgs : EventArgs
    {
        public string FifaCodeFavCountry { get; set; } = null!;
        public List<Player> Players { get; set; } = null!;
        public List<Player> FavPlayers { get; set; } = null!;
        public List<Player> NotFavPlayers { get; set; } = null!;
    }
}
