using DataLayer.Models;
using MatchView.CustomDesign;
using MatchView.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MatchView.UCs
{
    public partial class TeamOverviewUC : UserControl
    {
        private string _language;
        private Gender _championship;
        private string _favTeamFifaCode;
        private string _oppTeamFifaCode;

        private DataManager _dataManager = new();
        private List<Match> _matches;
        private List<Result> _results;
        private ResourceManager _resourceManager;
        private List<Team> _teams;

        public TeamOverviewUC(string language, Gender championship, string favTeamFifaCode, string oppTeamFifaCode)
        {
            InitializeComponent();

            _language = language;
            _championship = championship;
            _favTeamFifaCode = favTeamFifaCode;
            _oppTeamFifaCode = oppTeamFifaCode;

            SetLanguageResources();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            try
            {
                _teams = await FetchTeamsAsync();
                await GetMatchesAsync();
                await GetResultsAsync();

                FillFavComboBox();
                await FillOppComboBoxAsync();
            }
            catch 
            {
                CustomMessageBox.ShowCustomMessage("messageDataUnavaliable", "messageWarning", MessageBoxButton.OKCancel, _language);
            }
        }

        private void SetLanguageResources()
        {
            try
            {
                var culture = new CultureInfo(_language);
                var resourceName = $"MatchView.Properties.Resource_{_language}";

                _resourceManager = new ResourceManager(resourceName, typeof(TeamOverviewUC).Assembly);

                lbFavTeam.Content = _resourceManager.GetString("lbFavTeam", culture);
                lbOpponentTeam.Content = _resourceManager.GetString("lbOpponentTeam", culture);
            }
            catch (Exception)
            {
                CustomMessageBox.ShowCustomMessage("messageDataUnavaliable", "messageWarning", MessageBoxButton.OKCancel, _language);
            }
        }

        private async Task<List<Team>> FetchTeamsAsync()
        {
            await _dataManager.SetTeams(_championship);
            return _dataManager.GetTeams() ?? new List<Team>();
        }

        private async Task GetMatchesAsync()
        {
            await _dataManager.SetMatches(_championship);
            _matches = _dataManager.GetMatches() ?? new List<Match>();
        }

        private async Task GetResultsAsync()
        {
            await _dataManager.SetResults(_championship);
            _results = _dataManager.GetResults() ?? new List<Result>();
        }

        private async Task<List<Team>> GetOppTeamsAsync()
        {
            var oppositeTeams = new HashSet<Team>();
            var matchesOppTeam = await GetMatchesOppTeamAsync();

            foreach (var match in matchesOppTeam)
            {
                AddOppositeTeam(oppositeTeams, match.HomeTeam.Code);
                AddOppositeTeam(oppositeTeams, match.AwayTeam.Code);
            }

            return oppositeTeams.ToList();
        }

        private async Task<List<Match>> GetMatchesOppTeamAsync()
        {
            await _dataManager.SetMatchesByFifaCode(_championship, _favTeamFifaCode);
            return _dataManager.GetMatchesOppTeam();
        }

        private void AddOppositeTeam(HashSet<Team> oppositeTeams, string teamCode)
        {
            if (!string.IsNullOrEmpty(teamCode) && teamCode != _favTeamFifaCode)
            {
                var team = _teams?.FirstOrDefault(t => t.FifaCode == teamCode);
                if (team != null)
                {
                    oppositeTeams.Add(new Team { Id = team.Id, FifaCode = team.FifaCode, Country = team.Country });
                }
            }
        }

        private void FillFavComboBox()
        {
            comboBoxFavTeam.Items.Clear();

            if (_teams != null)
            {
                foreach (var team in _teams.OrderBy(t => t.Country))
                {
                    comboBoxFavTeam.Items.Add($"{team.Country} ({team.FifaCode})");
                }

                if (comboBoxFavTeam.Items.Count > 0)
                {
                    comboBoxFavTeam.SelectedIndex = _favTeamFifaCode == null
                        ? 0
                        : comboBoxFavTeam.Items.IndexOf(comboBoxFavTeam.Items.Cast<string>().FirstOrDefault(item => item.Contains(_favTeamFifaCode)));
                }
            }
        }

        private async Task FillOppComboBoxAsync()
        {
            if (_teams == null) return;

            var sortedTeams = (await GetOppTeamsAsync()).OrderBy(t => t.Country).ToList();
            var formattedTeams = sortedTeams.Select(team => $"{team.Country} ({team.FifaCode})").ToList();
            comboBoxOppTeam.ItemsSource = formattedTeams;

            if (!string.IsNullOrEmpty(_oppTeamFifaCode))
            {
                var selectedOppTeam = formattedTeams.FirstOrDefault(item => item.Contains(_oppTeamFifaCode));

                if (selectedOppTeam != null)
                {
                    comboBoxOppTeam.SelectedItem = selectedOppTeam;
                }
                else
                {
                    comboBoxOppTeam.SelectedIndex = 0;
                }
            }
        }

        private async void ComboBoxFavTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxFavTeam.SelectedItem != null)
            {
                await UpdateUI();
            }
        }

        private async Task UpdateUI()
        {
            await Dispatcher.InvokeAsync(async () =>
            {
                FillFavTeamList();
                await FillScoreLabelAsync();
            });

            await FillOppComboBoxAsync();
        }

        private async void ComboBoxOppTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxOppTeam.SelectedItem != null)
            {
                await Dispatcher.InvokeAsync(async () =>
                {
                    FillOppTeamList();
                    await FillScoreLabelAsync();
                });
            }
        }

        private async Task FillScoreLabelAsync()
        {
            await Dispatcher.InvokeAsync(() =>
            {
                string favoriteFifaCode = ExtractFifaCode(comboBoxFavTeam.SelectedItem);
                string oppositeFifaCode = ExtractFifaCode(comboBoxOppTeam.SelectedItem);

                var match = _matches.FirstOrDefault(m =>
                    (m.HomeTeam.Code == favoriteFifaCode && m.AwayTeam.Code == oppositeFifaCode) ||
                    (m.AwayTeam.Code == favoriteFifaCode && m.HomeTeam.Code == oppositeFifaCode));

                if (match != null)
                {
                    long goalsFavoriteTeam = match.HomeTeam.Code == favoriteFifaCode ? match.HomeTeam.Goals : match.AwayTeam.Goals;
                    long goalsOppositeTeam = match.HomeTeam.Code == oppositeFifaCode ? match.HomeTeam.Goals : match.AwayTeam.Goals;

                    lbScore.Content = $"{goalsFavoriteTeam} : {goalsOppositeTeam}";
                }
                else
                {
                    lbScore.Content = "x";
                }
            });
        }

        private string ExtractFifaCode(object selectedItem)
        {
            var teamString = selectedItem?.ToString();
            return teamString?.Substring(teamString.IndexOf("(") + 1, 3);
        }

        private void FillFavTeamList()
        {
            if (comboBoxFavTeam.Dispatcher.CheckAccess())
            {
                _favTeamFifaCode = ExtractFifaCode(comboBoxFavTeam.SelectedItem);

                var matchWithCode = _matches.FirstOrDefault(m => m.AwayTeam.Code == _favTeamFifaCode);

                if (matchWithCode != null)
                {
                    var players = matchWithCode.AwayTeamStatistics.StartingEleven
                                    .Concat(matchWithCode.AwayTeamStatistics.Substitutes).ToList();

                    lsFavTeam.ItemsSource = players;
                }
                else
                {
                    lsFavTeam.ItemsSource = null;
                    MessageBox.Show($"No matches found with FIFA code {_favTeamFifaCode}");
                }
            }
            else
            {
                Dispatcher.Invoke(() => FillFavTeamList());
            }
        }

        private void FillOppTeamList()
        {
            if (comboBoxOppTeam.Dispatcher.CheckAccess())
            {
                _oppTeamFifaCode = ExtractFifaCode(comboBoxOppTeam.SelectedItem);

                var matchWithCode = _matches.FirstOrDefault(m => m.HomeTeam.Code == _oppTeamFifaCode || m.AwayTeam.Code == _oppTeamFifaCode);

                if (matchWithCode != null)
                {
                    var players = matchWithCode.HomeTeam.Code == _oppTeamFifaCode
                        ? matchWithCode.HomeTeamStatistics.StartingEleven.Concat(matchWithCode.HomeTeamStatistics.Substitutes)
                        : matchWithCode.AwayTeamStatistics.StartingEleven.Concat(matchWithCode.AwayTeamStatistics.Substitutes);

                    lsOppTeam.ItemsSource = players.ToList();
                }
                else
                {
                    lsOppTeam.ItemsSource = null;
                    MessageBox.Show($"No matches found with FIFA code {_oppTeamFifaCode}");
                }
            }
            else
            {
                Dispatcher.Invoke(() => FillOppTeamList());
            }
        }

        // show team info
        private void ShowFavTeamInfo_Click(object sender, RoutedEventArgs e)
        {
            ShowTeamInfo(comboBoxFavTeam.SelectedItem);
        }

        private void ShowOppTeamInfo_Click(object sender, RoutedEventArgs e)
        {
            ShowTeamInfo(comboBoxOppTeam.SelectedItem);
        }

        private void ShowTeamInfo(object selectedItem)
        {
            if (selectedItem != null)
            {
                var fifaCode = ExtractFifaCode(selectedItem);

                var teamResult = _results.FirstOrDefault(r => r.FifaCode == fifaCode);
                if (teamResult != null)
                {
                    var teamInfoWindow = new TeamInfoWindow(_language);
                    teamInfoWindow.SetTeamData(teamResult);
                    teamInfoWindow.ShowDialog();
                }
                else
                {
                    CustomMessageBox.ShowCustomMessage("Team not found.", "Error", MessageBoxButton.OK, _language);
                }
            }
        }

        public event EventHandler<TeamOverviewEventArgs> TeamOverviewUpdated;
        private void OnNextButtonClick(object sender, RoutedEventArgs e)
        {
            var favTeamCode = ExtractFifaCode(comboBoxFavTeam.SelectedItem);
            var oppTeamCode = ExtractFifaCode(comboBoxOppTeam.SelectedItem);
            var matchResult = lbScore.Content.ToString();

            var teamOverviewArgs = new TeamOverviewEventArgs
            {
                FavTeam = favTeamCode,
                OpponentTeam = oppTeamCode,
                Result = matchResult,
                FootballMatches = _matches
            };

            TeamOverviewUpdated?.Invoke(this, teamOverviewArgs);
        }
    }
}