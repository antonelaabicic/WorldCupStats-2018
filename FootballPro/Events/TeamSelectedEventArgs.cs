using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPro.Events
{
    public class TeamSelectedEventArgs
    {
        public Team SelectedTeam { get; set; }

        public TeamSelectedEventArgs(Team selectedTeam)
        {
            SelectedTeam = selectedTeam;
        }
    }
}
