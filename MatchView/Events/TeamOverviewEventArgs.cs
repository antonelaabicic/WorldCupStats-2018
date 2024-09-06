using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchView.Events
{
    public class TeamOverviewEventArgs : EventArgs
    {
        public string FavTeam { get; set; } = null!;
        public string OpponentTeam { get; set; } = null!;

        public string Result { get; set; } = null!;
        public List<Match> FootballMatches { get; set; } = new();
    }
}
