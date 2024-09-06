using DataLayer.Models;
using FootballPro.CustomDesign;
using FootballPro.Events;
using FootballPro.Properties;
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
    public partial class FavouritePlayersUC : UserControl
    {
        private string _fifaCode;
        private string _language;
        private List<Match> _matches;
        private List<Player> _players;
        private List<Player> _favPlayers;
        private List<Player> _notFavPlayers;
        private Gender _gender;

        public event EventHandler<FavPlayersEventArgs> FavPlayersList;

        public FavouritePlayersUC(string fifaCode, Gender gender, List<Match> matches, List<Player> favPlayers, List<Player> notFavPlayers, string language)
        {
            InitializeComponent();
            _fifaCode = fifaCode;
            _language = language;
            _gender = gender;
            _matches = matches;
            _favPlayers = favPlayers;
            _notFavPlayers = notFavPlayers;

            SetTextBasedOnLanguage();

            pnlFavPlayers.DragEnter += Panel_DragEnter;
            pnlFavPlayers.DragDrop += Panel_DragDrop;
            pnlPlayers.DragEnter += Panel_DragEnter;
            pnlPlayers.DragDrop += Panel_DragDrop;
        }

        private void SetTextBasedOnLanguage()
        {
            btnSaveFavPlayers.Text = _language switch
            {
                "en-US" => Resource_en_US.btnSaveFavPlayers,
                "hr-HR" => Resource_hr_HR.btnSaveFavPlayers,
                "de-DE" => Resource_de_DE.btnSaveFavPlayers,
                _ => Resource_en_US.btnSaveFavPlayers
            };

            label1.Text = _language switch
            {
                "en-US" => Resource_en_US.lbAllPlayers,
                "hr-HR" => Resource_hr_HR.lbAllPlayers,
                "de-DE" => Resource_de_DE.lbAllPlayers,
                _ => Resource_en_US.lbAllPlayers
            };

            label2.Text = _language switch
            {
                "en-US" => Resource_en_US.lbFavPlayers,
                "hr-HR" => Resource_hr_HR.lbFavPlayers,
                "de-DE" => Resource_de_DE.lbFavPlayers,
                _ => Resource_en_US.lbFavPlayers
            };
        }

        private void FavouritePlayersUC_Load(object sender, EventArgs e)
        {
            if (_favPlayers != null && _notFavPlayers != null)
            {
                _players = _favPlayers.Concat(_notFavPlayers).ToList();

                SetPlayersPanel(_favPlayers, pnlFavPlayers);
                SetPlayersPanel(_notFavPlayers, pnlPlayers);
            }
            else
            {
                SetPlayersFromMatches();
                SetPlayersPanel(_players, pnlPlayers);
            }
        }

        private void SetPlayersPanel(List<Player> players, FlowLayoutPanel panel)
        {
            foreach (var player in players)
            {
                PlayerUC playerUC = new PlayerUC(_gender, player, _language);

                PictureBox? pbStar = playerUC.Controls.Find("pbStar", true).FirstOrDefault() as PictureBox;
                if (pbStar != null)
                {
                    pbStar.Visible = panel == pnlFavPlayers;
                }

                panel.Controls.Add(playerUC);
            }
        }

        private void SetPlayersFromMatches()
        {
            var matchWithCode = _matches.FirstOrDefault(m => m.AwayTeam.Code.Equals(_fifaCode));

            if (matchWithCode != null)
            {
                _players = matchWithCode.AwayTeamStatistics.StartingEleven.Concat(matchWithCode.AwayTeamStatistics.Substitutes).ToList();
            }
            else
            {
                MessageBox.Show($"No matches found with FIFA code {_fifaCode}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // arrow events
        private void pbLeftArrow_Click(object sender, EventArgs e)
        {
            MoveSelectedPlayers(pnlFavPlayers, pnlPlayers);
        }

        private void pbRightArrow_Click(object sender, EventArgs e)
        {
            if (pnlFavPlayers.Controls.OfType<PlayerUC>().Count() >= 3)
            {
                CustomMessageBox.Show(
                    GetLocalizedResource("messageWarningThreePlayers"),
                    GetLocalizedResource("messageWarning"),
                    MessageBoxButtons.OK,
                    _language
                );
                DeselectPlayers(pnlPlayers.Controls.OfType<PlayerUC>().Where(p => p.IsSelected).ToList());
                return;
            }

            MoveSelectedPlayers(pnlPlayers, pnlFavPlayers);
        }

        private void MoveSelectedPlayers(FlowLayoutPanel fromPanel, FlowLayoutPanel toPanel)
        {
            var selectedPlayers = fromPanel.Controls.OfType<PlayerUC>().Where(p => p.IsSelected).ToList();
            int favPlayersCount = pnlFavPlayers.Controls.OfType<PlayerUC>().Count();

            if (toPanel == pnlFavPlayers && favPlayersCount + selectedPlayers.Count > 3)
            {
                CustomMessageBox.Show(
                    GetLocalizedResource("messageWarningThreePlayers"),
                    GetLocalizedResource("messageWarning"),
                    MessageBoxButtons.OK,
                    _language
                );
                DeselectPlayers(selectedPlayers);
                return;
            }

            foreach (var playerUC in selectedPlayers)
            {
                fromPanel.Controls.Remove(playerUC);
                playerUC.IsSelected = false;
                playerUC.BackColor = _gender == Gender.Men ? Color.ForestGreen : Color.SteelBlue;
                PictureBox? pbStar = playerUC.Controls.Find("pbStar", true).FirstOrDefault() as PictureBox;
                if (pbStar != null)
                {
                    pbStar.Visible = toPanel == pnlFavPlayers;
                }
                toPanel.Controls.Add(playerUC);
            }
        }

        // drag-n-drop
        private void Panel_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlayerUC)) || e.Data.GetDataPresent(typeof(List<PlayerUC>)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Panel_DragDrop(object? sender, DragEventArgs e)
        {
            FlowLayoutPanel targetPanel = sender as FlowLayoutPanel;
            var draggedPlayerUCs = e.Data.GetData(typeof(List<PlayerUC>)) as List<PlayerUC>;
            if (draggedPlayerUCs == null)
            {
                draggedPlayerUCs = new List<PlayerUC> { e.Data.GetData(typeof(PlayerUC)) as PlayerUC };
            }

            if (targetPanel != null && draggedPlayerUCs != null && draggedPlayerUCs.Any())
            {
                if (targetPanel == pnlFavPlayers && pnlFavPlayers.Controls.OfType<PlayerUC>().Count() + draggedPlayerUCs.Count > 3)
                {
                    CustomMessageBox.Show(
                        GetLocalizedResource("messageWarningThreePlayers"),
                        GetLocalizedResource("messageWarning"),
                        MessageBoxButtons.OK,
                        _language
                    );
                    DeselectPlayers(draggedPlayerUCs);
                    return;
                }

                foreach (var draggedPlayerUC in draggedPlayerUCs)
                {
                    FlowLayoutPanel parentPanel = draggedPlayerUC.Parent as FlowLayoutPanel;
                    if (parentPanel != null)
                    {
                        parentPanel.Controls.Remove(draggedPlayerUC);
                    }

                    PictureBox pbStar = draggedPlayerUC.Controls.Find("pbStar", true).FirstOrDefault() as PictureBox;
                    if (pbStar != null)
                    {
                        pbStar.Visible = targetPanel == pnlFavPlayers;
                    }

                    draggedPlayerUC.IsSelected = false;
                    draggedPlayerUC.BackColor = _gender == Gender.Men ? Color.ForestGreen : Color.SteelBlue;
                    targetPanel.Controls.Add(draggedPlayerUC);
                }
            }
        }

        private void DeselectPlayers(List<PlayerUC> players)
        {
            foreach (var playerUC in players)
            {
                playerUC.IsSelected = false;
                playerUC.BackColor = _gender == Gender.Men ? Color.ForestGreen : Color.SteelBlue;
            }
        }

        private void BtnFavPlayersSaved_Click(object sender, EventArgs e)
        {
            _favPlayers = pnlFavPlayers.Controls.OfType<PlayerUC>().Select(p => p.GetPlayer()).ToList();
            _notFavPlayers = pnlPlayers.Controls.OfType<PlayerUC>().Select(p => p.GetPlayer()).ToList();

            if (_favPlayers.Count != 3)
            {
                CustomMessageBox.Show(
                    GetLocalizedResource("messageWarningThreePlayers"),
                    GetLocalizedResource("messageWarning"),
                    MessageBoxButtons.OK,
                    _language
                );
                return;
            }

            FavPlayersList?.Invoke(this, new FavPlayersEventArgs
            {
                FifaCodeFavCountry = _fifaCode,
                FavPlayers = _favPlayers,
                NotFavPlayers = _notFavPlayers,
                Players = _players
            });
        }

        private string? GetLocalizedResource(string resourceKey)
        {
            return _language switch
            {
                "en-US" => Resource_en_US.ResourceManager.GetString(resourceKey),
                "hr-HR" => Resource_hr_HR.ResourceManager.GetString(resourceKey),
                "de-DE" => Resource_de_DE.ResourceManager.GetString(resourceKey),
                _ => Resource_en_US.ResourceManager.GetString(resourceKey)
            };
        }
    }
}