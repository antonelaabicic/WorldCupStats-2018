using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MatchView
{
    /// <summary>
    /// Interaction logic for PlayerDataWindow.xaml
    /// </summary>
    public partial class PlayerDataWindow : Window
    {
        private Player _player;
        private List<Player> _players;
        private List<Match> _matches;
        private string _favTeamFifaCode;
        private string _oppTeamFifaCode;

        public PlayerDataWindow(Player player, List<Player> players, List<Match> matches, string favTeamFifaCode, string oppTeamFifaCode)
        {
            InitializeComponent();

            _favTeamFifaCode = favTeamFifaCode;
            _oppTeamFifaCode = oppTeamFifaCode;
            _player = player;
            _player.GoalsCount = 0;
            _player.YellowCardCount = 0;
            _players = players;
            _matches = matches;

            UpdatePlayerStatistics();
            InitializePlayer(_player);
            this.Loaded += OnWindowLoaded;
        }

        private void InitializePlayer(Player player)
        {
            string imagePath = null!;
            if (player.ImagePath == "../../../../DataLayer/Images/female_player.png")
            {
                imagePath = "/Resources/female_player.png";
            }
            else if (player.ImagePath == "../../../../DataLayer/Images/male_player.png")
            {
                imagePath = "/Resources/male_player.png";
            }
            else
            {
                imagePath = player.ImagePath;
            }

            Uri imageUri;
            if (Uri.IsWellFormedUriString(imagePath, UriKind.RelativeOrAbsolute))
            {
                imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            }
            else
            {
                imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            }

            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = imageUri;
            bitmapImage.EndInit();

            playerImg.Source = bitmapImage;

            if (player.Name.Length > 15)
            {
                lbName.FontSize = 12;
            }
            lbName.Content = player.Name;

            lbIsCaptain.Source = new BitmapImage(new Uri(player.Captain ? "/Resources/tick.png" : "/Resources/delete.png", UriKind.RelativeOrAbsolute));
            lbShirtNo.Content = player.ShirtNumber.ToString();
            lbPosition.Content = player.Position;
            lbGoals.Content = player.GoalsCount.ToString();
            lbYellowCards.Content = player.YellowCardCount.ToString();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            var storyboard = (Storyboard)FindResource("FadeInStoryboard");
            storyboard.Begin(this);
        }

        private void UpdatePlayerStatistics()
        {
            foreach (var match in _matches)
            {
                if ((match.HomeTeam.Code == _favTeamFifaCode && match.AwayTeam.Code == _oppTeamFifaCode) ||
                    (match.HomeTeam.Code == _oppTeamFifaCode && match.AwayTeam.Code == _favTeamFifaCode))
                {
                    bool isPlayerInHomeTeam = match.HomeTeamEvents.Any(e => e.Player.Equals(_player.Name, StringComparison.OrdinalIgnoreCase));
                    bool isPlayerInAwayTeam = match.AwayTeamEvents.Any(e => e.Player.Equals(_player.Name, StringComparison.OrdinalIgnoreCase));
                    
                    if (isPlayerInHomeTeam)
                    {
                        UpdateTeamStatistics(match.HomeTeamEvents); 
                    }
                    else if (isPlayerInAwayTeam)
                    {
                        UpdateTeamStatistics(match.AwayTeamEvents); 
                    } 
                }
            }
        }

        private void UpdateTeamStatistics(List<TeamEvent> matchEvents)
        {
            foreach (var matchEvent in matchEvents)
            {
                if (matchEvent.TypeOfEvent.Equals("goal") || matchEvent.TypeOfEvent.Equals("yellow-card"))
                {
                    if (_player != null && _player.Name == matchEvent.Player)
                    {
                        switch (matchEvent.TypeOfEvent)
                        {
                            case "goal":
                                _player.GoalsCount += 1;
                                break;
                            case "yellow-card":
                                _player.YellowCardCount += 1;
                                break;
                            default:
                                MessageBox.Show($"Unknown event type {matchEvent.TypeOfEvent} encountered.", "Warning");
                                break;
                        }
                    }
                }
            }
        }
    }
}
