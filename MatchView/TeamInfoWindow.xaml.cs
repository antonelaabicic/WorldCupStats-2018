using DataLayer.Models;
using MatchView.CustomDesign;
using MatchView.UCs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
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
    /// Interaction logic for TeamInfoWindow.xaml
    /// </summary>
    public partial class TeamInfoWindow : Window
    {
        private string _language;
        private ResourceManager _resourceManager;

        public TeamInfoWindow(string language)
        {
            InitializeComponent();
            _language = language;

            SetLanguageResources(); 
            this.Loaded += OnWindowLoaded;
        }

        private void SetLanguageResources()
        {
            try
            {
                var culture = new CultureInfo(_language);
                var resourceName = $"MatchView.Properties.Resource_{_language}";

                _resourceManager = new ResourceManager(resourceName, typeof(TeamInfoWindow).Assembly);

                lbCountry.Content = _resourceManager.GetString("lbCountry", culture);
                lbFifaCode.Content = _resourceManager.GetString("lbFifaCode", culture);
                lbGamesPlayed.Content = _resourceManager.GetString("lbGamesPlayed", culture);
                lbGamesWon.Content = _resourceManager.GetString("lbGamesWon", culture);
                lbGamesLost.Content = _resourceManager.GetString("lbGamesLost", culture);
                lbGamesDrawn.Content = _resourceManager.GetString("lbGamesDrawn", culture);
                lbGoalsScored.Content = _resourceManager.GetString("lbGoalsScored", culture);
                lbGoalsConceded.Content = _resourceManager.GetString("lbGoalsConceded", culture);
                lbGoalDifference.Content = _resourceManager.GetString("lbGoalDifference", culture);
            }
            catch (Exception)
            {
                CustomMessageBox.ShowCustomMessage("messageDataUnavaliable", "messageWarning", MessageBoxButton.OKCancel, _language);
            }
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            var fadeInScaleStoryboard = (Storyboard)Application.Current.Resources["FadeInScaleStoryboard"];
            fadeInScaleStoryboard.Begin(this);
        }

        public void SetTeamData(Result teamResult)
        {
            lbCountryValue.Content = teamResult.Country;
            lbFifaCodeValue.Content = teamResult.FifaCode;
            lbGamesPlayedValue.Content = teamResult.GamesPlayed;
            lbGamesWonValue.Content = teamResult.Wins;
            lbGamesLostValue.Content = teamResult.Losses;
            lbGamesDrawnValue.Content = teamResult.Draws;
            lbGoalsScoredValue.Content = teamResult.GoalsFor;
            lbGoalsConcededValue.Content = teamResult.GoalsAgainst;
            lbGoalDifferenceValue.Content = teamResult.GoalDifferential;
        }
    }
}
