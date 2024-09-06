using DataLayer.Models;
using FootballPro.Events;
using FootballPro.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballPro.UCs
{
    public partial class FavouriteTeamUC : UserControl
    {
        private List<Team> _teams;
        private string _fifaCode;
        private string _language;

        public event EventHandler<TeamSelectedEventArgs> TeamSelected;

        public FavouriteTeamUC(List<Team> teams, string fifaCode, string language)
        {
            InitializeComponent();

            _teams = teams;
            _fifaCode = fifaCode;
            _language = language;

            SetTextBasedOnLanguage();
            FillTeamsCB();
        }

        private void SetTextBasedOnLanguage()
        {
            label2.Text = _language switch
            {
                "en-US" => Resource_en_US.btnTeamFav,
                "hr-HR" => Resource_hr_HR.btnTeamFav,
                "de-DE" => Resource_de_DE.btnTeamFav,
                _ => Resource_en_US.btnTeamFav
            };

            btnFavTeam.Text = _language switch
            {
                "en-US" => Resource_en_US.btnSave,
                "hr-HR" => Resource_hr_HR.btnSave,
                "de-DE" => Resource_hr_HR.btnSave,
                _ => Resource_en_US.btnSave
            };
        }

        private void FillTeamsCB()
        {
            cbTeams.Items.Clear();

            if (cbTeams != null)
            {
                cbTeams.Items.AddRange(_teams.OrderBy(t => t.Country).ToArray()); 

                if (_fifaCode == null)
                {
                    cbTeams.SelectedIndex = 0;
                }
                else
                {
                    foreach (var item in cbTeams.Items)
                    {
                        if ((_fifaCode).Equals(item.ToString().Substring(item.ToString().IndexOf("(") + 1, 3)))
                        {
                            cbTeams.SelectedIndex = cbTeams.Items.IndexOf(item); 
                            break;
                        }
                    }
                }
            }
        }

        private void btnFavTeam_Click(object sender, EventArgs e)
        {
            
            if (cbTeams.SelectedItem != null)
            {
                Team selectedTeam = (Team)cbTeams.SelectedItem;
                OnTeamSelected(new TeamSelectedEventArgs(selectedTeam));
            }
            else
            {
                MessageBox.Show("Please select a team.", "No team selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected virtual void OnTeamSelected(TeamSelectedEventArgs e)
        {
            TeamSelected?.Invoke(this, e);
        }
    }
}
