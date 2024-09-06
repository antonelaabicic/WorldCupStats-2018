using DataLayer.Models;
using MatchView.CustomDesign;
using MatchView.Events;
using MatchView.UCs;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static MatchView.CustomDesign.CustomMessageBox;

namespace MatchView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataManager _dataManager = new();

        private string _language;
        private Gender _championship;
        private ScreenSize _screenSize;
        private InitialFPSettings _initialSettings = new();

        private string _favTeamFifaCode;
        private string _oppTeamFifaCode;
        private List<Player> _players;
        private List<Player> _favPlayers;
        private List<Player> _notFavPlayers;
        private FavCountryAndPlayers _favSettings = new();

        private LoadingWindow _loadingWindow;
        private string _result;
        private List<Match> _matches;

        public MainWindow()
        {
            InitializeComponent(); 
            InitializeSettingsAsync();
        }

        private async void InitializeSettingsAsync()
        {
            await SetInitialSettings();
            

            _loadingWindow = new LoadingWindow(_language);

            SetLanguage();
            CallFirstScreen();
            SetScreenSize();
        }

        private async Task SetInitialSettings()
        {
            try
            {
                await _dataManager.LoadSavedSettings();

                _language = _dataManager.GetLanguage() ?? "en-US";
                _championship = _dataManager.GetChampionship();

                _screenSize = _dataManager.GetScreenSize();

                _favTeamFifaCode = _dataManager.GetFavFifaCode();
                _oppTeamFifaCode = _dataManager.GetOpponentFifaCode();

                _favPlayers = _dataManager.GetFavPlayers();
                _notFavPlayers = _dataManager.GetNotFavPlayers();
                _players = (_favPlayers?.Concat(_notFavPlayers) ?? Enumerable.Empty<Player>()).ToList();
            }
            catch (Exception)
            {
                CustomMessageBox.ShowFromResources("messageDataUnavaliable", "messageWarning", MessageBoxButton.OKCancel, _language);
            }
        }

        private void SetLanguage()
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(_language ?? "en-US");

                if (_loadingWindow != null)
                {
                    _loadingWindow.Close();
                    _loadingWindow = new LoadingWindow(_language);
                }
            }
            catch (CultureNotFoundException)
            {
                CustomMessageBox.ShowFromResources("messageDefaultEnglish", "messageWarning", MessageBoxButton.OKCancel, _language);
            }
        }

        private void SetScreenSize()
        {
            Window window = this;

            switch (_screenSize)
            {
                case ScreenSize.Original:
                    if (window.WindowState == WindowState.Maximized)
                    {
                        window.WindowState = WindowState.Normal;
                    }
                    window.Width = 1500;
                    window.Height = 800;
                    window.Left = (SystemParameters.PrimaryScreenWidth / 2) - (window.Width / 2);
                    window.Top = (SystemParameters.PrimaryScreenHeight / 2) - (window.Height / 2);
                    break;

                case ScreenSize.Small:
                    if (window.WindowState == WindowState.Maximized)
                    {
                        window.WindowState = WindowState.Normal;
                    }
                    window.Width = 1350;
                    window.Height = 720;
                    window.Left = (SystemParameters.PrimaryScreenWidth / 2) - (window.Width / 2);
                    window.Top = (SystemParameters.PrimaryScreenHeight / 2) - (window.Height / 2);
                    break;

                case ScreenSize.Fullscreen:
                    window.WindowState = WindowState.Maximized;
                    break;
                default:
                    break;
            }
        }

        private async void CallFirstScreen()
        {
            bool hasInitialSettings = _language != null && _screenSize != null && _championship != null;

            _loadingWindow.StartLoader();

            if (hasInitialSettings)
            {
                await Task.Delay(2000);
                CallTeamOverview();
            }
            else
            {
                await Task.Delay(2000);
                CallInitialSettings();
            }

            _loadingWindow.StopLoader();
        }


        // settings
        private void CallInitialSettings()
        {
            SettingsUC settings = new SettingsUC(_language, _championship, _screenSize);
            settings.SettingsSaved += Settings_SettingsSaved;
            MainContent.Content = settings;
        }

        private async void Settings_SettingsSaved(object? sender, Events.SettingsChangedEventArgs e)
        {
            UpdateSettings(e);
            await _dataManager.SaveInitialSettingsToRepo(_initialSettings);
            ApplySettings();
        }

        private void UpdateSettings(SettingsChangedEventArgs e)
        {
            _initialSettings.Language = _language = e.Language;
            _initialSettings.Championship = _championship = e.Championship;
            _initialSettings.ScreenSize = _screenSize = e.ScreenSize;
        }

        private void ApplySettings()
        {
            SetLanguage();
            SetScreenSize(); 
            CallTeamOverview();
        }

        // overview
        private async void CallTeamOverview()
        {
            TeamOverviewUC overview = new TeamOverviewUC(_language, _championship, _favTeamFifaCode, _oppTeamFifaCode);
            overview.TeamOverviewUpdated += Overview_TeamOverviewUpdated;
            MainContent.Content = overview;
        }

        private async void Overview_TeamOverviewUpdated(object? sender, TeamOverviewEventArgs e)
        {
            _result = e.Result;
            _matches = e.FootballMatches;
            string teamCode = e.FavTeam;
            _oppTeamFifaCode = e.OpponentTeam;

            if (_favTeamFifaCode != teamCode)
            {
                _favSettings.FifaCodeFavCountry = teamCode;
                _favSettings.OpponentTeam = _oppTeamFifaCode;
                _favSettings.FavPlayers = null;
                _favSettings.NotFavPlayers = null;
                _favTeamFifaCode = teamCode;
            }
            else
            {
                UpdateFavSettings();
            }
            UpdateInitialSettings();

            await _dataManager.SaveFavPlayers(_favSettings);
            await _dataManager.SaveInitialSettingsToRepo(_initialSettings);
            SetScreenSize();
            await SetInitialSettings();
            CallMatchPlayers();
        }

        private void CallMatchPlayers()
        {
            MatchPlayers matchPlayers = new MatchPlayers(_championship, _favTeamFifaCode, _oppTeamFifaCode, _result, _matches, _players, _screenSize);
            matchPlayers.BackClick += MatchPlayers_BackClick;
            MainContent.Content = matchPlayers;
        }

        private void MatchPlayers_BackClick(object? sender, EventArgs e)
        {
            CallTeamOverview();
        }

        private async void OnWindowClosing(object sender, CancelEventArgs e)
        {
            var result = CustomMessageBox.ShowFromResources("messageLeaving", "messageWarning", MessageBoxButton.YesNo, _language);

            if (result == false)
            {
                e.Cancel = true;
            }

            UpdateInitialSettings();
            await _dataManager.SaveInitialSettingsToRepo(_initialSettings);

            UpdateFavSettings();
            await _dataManager.SaveFavPlayers(_favSettings);
        }

        private void UpdateInitialSettings()
        {
            _initialSettings.Language = _language;
            _initialSettings.Championship = _championship;
            _initialSettings.ScreenSize = _screenSize;
        }

        private void UpdateFavSettings()
        {
            _favSettings.FifaCodeFavCountry = _favTeamFifaCode;
            _favSettings.OpponentTeam = _oppTeamFifaCode;
            _favSettings.FavPlayers = _favPlayers;
            _favSettings.NotFavPlayers = _notFavPlayers;
        }

        private void OnSettingsBtnClick(object sender, RoutedEventArgs e)
        {
            SetScreenSize();
            CallInitialSettings();
        }
    }
}