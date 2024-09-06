using DataLayer.Models;
using DataLayer.Repository;
using FootballPro.CustomDesign;
using FootballPro.Events;
using FootballPro.Properties;
using FootballPro.UCs;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballPro
{
    public partial class MainForm : Form
    {
        private Gender _championship;
        private string _fifaCode;
        private string _language;

        private DataManager _dataManager = new();
        SplashScreenUC? _splashscreen;
        LoadingForm _loadingForm;

        private FavouriteTeamUC _favTeamForm;
        private FavCountryAndPlayers _favCountryAndPlayers = new();
        private List<Player> _favPlayers;
        private List<Player> _notFavPlayers;
        private FavouritePlayersUC _favPlayersForm;
        private RankingListUC _rankingListForm;
        private InitialFPSettings _initialFPSettings = new();

        private SettingsUC _settingsForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            CallSplashScreen();
            await _dataManager.LoadSavedSettings();
            LoadSettingsFromFile();
            _loadingForm = new LoadingForm(_language);
            SetNextScreen();
        }

        // splash screen
        private void CallSplashScreen()
        {
            _splashscreen = new SplashScreenUC();
            _splashscreen.ProgressCompleted += SplashScreen_ProgressCompleted;

            this.Controls.Add(_splashscreen);
            _splashscreen.BringToFront();
        }

        private void SplashScreen_ProgressCompleted(object sender, EventArgs e)
        {
            if (_splashscreen != null)
            {
                this.Controls.Remove(_splashscreen);
            }
        }

        // after splash screen
        private void SetNextScreen()
        {
            if (_language == null)
            {
                _language = "en-US";
                CallSettingsForm();
            }
            else if (_fifaCode == null) { CallFavTeamForm(); }
            else { CallFavPlayersForm(); }
        }

        // settings
        private void CallSettingsForm()
        {
            SetLanguage();
            _settingsForm = new SettingsUC(_language, _championship);
            _settingsForm.SettingsSaved += _settingsForm_SettingsSaved;
            _settingsForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(_settingsForm);
        }

        private async void _settingsForm_SettingsSaved(object? sender, SettingsEventArgs e)
        {
            _initialFPSettings.Language = e.Language;
            _initialFPSettings.Championship = e.Championship;
            SetLanguage();

            try
            {
                _loadingForm.StartLoader();
                await Task.Delay(1000);
                await _dataManager.SaveInitialSettingsToRepo(_initialFPSettings);
                _loadingForm.StopLoader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            _language = _initialFPSettings.Language;
            _championship = _initialFPSettings.Championship;

            pnlMain.Controls.Clear();
            CallFavTeamForm();
        }

        // favourite team
        private async void CallFavTeamForm()
        {
            try
            {
                await _dataManager.SetTeams(_championship);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var allTeams = _dataManager.GetTeams();
            _favTeamForm = new FavouriteTeamUC(allTeams, _fifaCode, _language);
            _favTeamForm.Dock = DockStyle.Fill;
            _favTeamForm.TeamSelected += _favTeamForm_TeamSelected;
            pnlMain.Controls.Add(_favTeamForm);
        }

        private async void _favTeamForm_TeamSelected(object? sender, TeamSelectedEventArgs e)
        {
            var selectedTeam = e.SelectedTeam;
            if (selectedTeam.FifaCode != _fifaCode)
            {
                _fifaCode = selectedTeam.FifaCode;
                _favCountryAndPlayers.FavPlayers = null!;
                _favCountryAndPlayers.NotFavPlayers = null!;
            }
            else
            {
                _favCountryAndPlayers.FavPlayers = _favPlayers;
                _favCountryAndPlayers.NotFavPlayers = _notFavPlayers;
            }
            _favCountryAndPlayers.FifaCodeFavCountry = _fifaCode;

            await SaveSettingsToFile();
            await _dataManager.LoadSavedSettings();
            LoadSettingsFromFile();
            CallFavPlayersForm();
        }

        private async Task SaveSettingsToFile()
        {
            SetLanguage();
            try
            {
                _loadingForm.StartLoader();
                await Task.Delay(1000);
                await _dataManager.SaveFavPlayers(_favCountryAndPlayers);
                await _dataManager.SaveInitialSettingsToRepo(_initialFPSettings);

                _loadingForm.StopLoader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadSettingsFromFile()
        {
            try
            {
                _language = _dataManager.GetLanguage();
                _championship = _dataManager.GetChampionship();

                _fifaCode = _dataManager.GetFavFifaCode();
                _favPlayers = _dataManager.GetFavPlayers();
                _notFavPlayers = _dataManager.GetNotFavPlayers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK);
            }
        }

        // favourite players
        private async void CallFavPlayersForm()
        {
            pnlMain.Controls.Clear();
            SetLanguage();

            try
            {
                _loadingForm.StartLoader();

                await _dataManager.SetMatches(_championship);
                await Task.Delay(2000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK);
                _loadingForm.StopLoader();
            }

            var matches = _dataManager.GetMatches();
            _favPlayersForm = new FavouritePlayersUC(_fifaCode, _championship, matches, _favPlayers, _notFavPlayers, _language);
            _favPlayersForm.Dock = DockStyle.Fill;
            _favPlayersForm.FavPlayersList += BtnFavPlayersSaved_Click;
            pnlMain.Controls.Add(_favPlayersForm);

            _loadingForm.StopLoader();
        }

        private async void BtnFavPlayersSaved_Click(object? sender, FavPlayersEventArgs e)
        {
            _initialFPSettings.Language = _language;
            _fifaCode = e.FifaCodeFavCountry;
            _favCountryAndPlayers.FifaCodeFavCountry = e.FifaCodeFavCountry;
            _favCountryAndPlayers.FavPlayers = e.FavPlayers;
            _favCountryAndPlayers.NotFavPlayers = e.NotFavPlayers;

            var playersForCountry = e.Players;
            await SaveSettingsToFile();
            CallRankingListForm(_fifaCode, playersForCountry);
        }

        private async void CallRankingListForm(string fifaCode, List<Player> playersForCountry)
        {
            pnlMain.Controls.Clear();
            SetLanguage();

            _loadingForm.StartLoader();
            await Task.Delay(1000);
            var matches = _dataManager.GetMatches();

            _rankingListForm = new RankingListUC(fifaCode, _language, matches, playersForCountry);
            _rankingListForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(_rankingListForm);
            _loadingForm.StopLoader();
        }

        private async void pbSettings_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            await SaveSettingsToFile();
            await _dataManager.ClearFavoritePlayersSettings();
            CallSettingsForm();
        }

        private void SetLanguage()
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(_language);
                if (_loadingForm != null)
                {
                    _loadingForm.Close();
                    _loadingForm = new LoadingForm(_language);
                }
            }
            catch (CultureNotFoundException)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                MessageBox.Show("The selected language is not supported. Defaulting to English.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string warning = "";
            string message = "";

            if (_language == "en-US")
            {
                warning = Resource_en_US.messageWarning;
                message = Resource_en_US.messageLeaving;
            }
            else if (_language == "hr-HR")
            {
                warning = Resource_hr_HR.messageWarning;
                message = Resource_hr_HR.messageLeaving;
            }
            else if (_language == "de-DE")
            {
                warning = Resource_de_DE.messageWarning;
                message = Resource_de_DE.messageLeaving;
            }

            var result = CustomMessageBox.Show(message, warning, MessageBoxButtons.OKCancel, _language);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true; 
            }
            await SaveSettingsToFile();
        }
    }
}
