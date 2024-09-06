using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballPro.UCs
{
    public partial class VisitorsUC : UserControl
    {
        private Match _match;

        public VisitorsUC(Match match)
        {
            InitializeComponent();

            _match = match;
            InitializeMatch();
        }

        private void InitializeMatch()
        {
            string homeTeamCountry = _match.HomeTeamCountry;
            string awayTeamCountry = _match.AwayTeamCountry;

            lbTeamVsTeam.Text = $"{homeTeamCountry} : {awayTeamCountry}";
            lbVenue.Text = _match.Venue;
            lbLocation.Text = _match.Location;
            lbNoVisitors.Text = _match.Attendance.ToString();
        }
    }
}
