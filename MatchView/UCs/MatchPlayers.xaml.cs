using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchView.UCs
{
    /// <summary>
    /// Interaction logic for MatchPlayers.xaml
    /// </summary>
    public partial class MatchPlayers : UserControl
    {
        private Gender _championship;

        private string _favTeamFifaCode;
        private string _oppTeamFifaCode;
        private string _result;
        private ScreenSize _screenSize;

        private List<Match> _matches;
        private List<Player> _players;

        private List<Player> _favMatchPlayers = new();
        private List<Player> _oppMatchPlayers = new();

        public MatchPlayers(Gender championship, string favTeamFifaCode, string oppTeamFifaCode, string result, List<Match> matches, List<Player> players, ScreenSize screenSize)
        {
            InitializeComponent();

            _championship = championship;
            _favTeamFifaCode = favTeamFifaCode;
            _oppTeamFifaCode = oppTeamFifaCode;
            _result = result;
            _matches = matches;
            _players = players;
            _screenSize = screenSize;

            FillMatchPlayers();
            FillMatchPlayersPositions();
            FillLabels();
        }

        private void FillMatchPlayers()
        {
            foreach (var match in _matches)
            {
                bool isHomeTeam = match.HomeTeam.Code == _favTeamFifaCode && match.AwayTeam.Code == _oppTeamFifaCode;
                bool isAwayTeam = match.HomeTeam.Code == _oppTeamFifaCode && match.AwayTeam.Code == _favTeamFifaCode;

                if (isHomeTeam || isAwayTeam)
                {
                    var favTeamStats = isHomeTeam ? match.HomeTeamStatistics : match.AwayTeamStatistics;
                    var oppTeamStats = isHomeTeam ? match.AwayTeamStatistics : match.HomeTeamStatistics;

                    _favMatchPlayers.AddRange(favTeamStats.StartingEleven);
                    _oppMatchPlayers.AddRange(oppTeamStats.StartingEleven);
                }
            }
        }

        private void FillMatchPlayersPositions()
        {
            AddPlayersToStackPanel(_favMatchPlayers, spGoalieFav, spDefenderFav, spMidfieldFav, spFowardFav, true);
            AddPlayersToStackPanel(_oppMatchPlayers, spGoalieOpp, spDefenderOpp, spMidfieldOpp, spFowardOpp, false);
        }

        private void AddPlayersToStackPanel(List<Player> players, StackPanel goaliePanel, StackPanel defenderPanel, 
            StackPanel midfieldPanel, StackPanel forwardPanel, bool isFavTeam)
        {
            foreach (var player in players) 
            {
                string imgPath = null!;
                foreach (var _player in _players)
                {
                    if (_player.Name == player.Name)
                    {
                        imgPath = _player.ImagePath;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(imgPath))
                {
                    imgPath = _championship == Gender.Men
                        ? "../../../../DataLayer/Images/male_player.png"
                        : "../../../../DataLayer/Images/female_player.png";
                }

                PlayerUC playerUC = new PlayerUC (_championship, isFavTeam, player, _screenSize);
                playerUC.SetPlayerImagePath(imgPath);

                playerUC.PlayerTransferData += PlayerUC_PlayerTransferData;

                switch (player.Position)
                {
                    case "Goalie":
                        goaliePanel.Children.Add(playerUC);
                        break;
                    case "Defender":
                        defenderPanel.Children.Add(playerUC);
                        break;
                    case "Midfield":
                        midfieldPanel.Children.Add(playerUC);
                        break;
                    case "Forward":
                        forwardPanel.Children.Add(playerUC);
                        break;
                }
            }
        }

        private void PlayerUC_PlayerTransferData(object? sender, Events.PlayerDataEventArgs e)
        {
            PlayerDataWindow playerDataWindow = new PlayerDataWindow(e.Player, _players, _matches, _favTeamFifaCode, _oppTeamFifaCode);
            playerDataWindow.ShowDialog();
        }

        private void FillLabels()
        {
            lbScore.Content = _result;

            var relevantMatch = _matches.FirstOrDefault(m =>
                (m.HomeTeam.Code == _favTeamFifaCode && m.AwayTeam.Code == _oppTeamFifaCode) ||
                (m.HomeTeam.Code == _oppTeamFifaCode && m.AwayTeam.Code == _favTeamFifaCode));

            if (relevantMatch != null)
            {
                bool isFavTeamHome = relevantMatch.HomeTeam.Code == _favTeamFifaCode;

                lbFavTeam.Content = isFavTeamHome ? relevantMatch.HomeTeam.Country : relevantMatch.AwayTeam.Country;
                lblOppTeam.Content = isFavTeamHome ? relevantMatch.AwayTeam.Country : relevantMatch.HomeTeam.Country;

                imgFavTeamFlag.Source = new BitmapImage(new Uri($"/Resources/{_favTeamFifaCode}_flag.png", UriKind.Relative));
                imgOppTeamFlag.Source = new BitmapImage(new Uri($"/Resources/{_oppTeamFifaCode}_flag.png", UriKind.Relative));
            }
        }

        public event EventHandler BackClick;
        private void OnGoingBack_Click(object sender, RoutedEventArgs e)
        {
            BackClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
