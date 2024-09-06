using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DataManager
    {
        private static IRepository _repository;
        private static readonly HttpClient _httpClient = new HttpClient();
        private ISettingsRepository _settingsRepository = RepositoryFactory.GetSettings();

        private List<Team> _teams = null!;
        private List<Result> _results = null!;
        private List<Player> _favPlayers = null!;
        private List<Player> _notFavPlayers;
        private string _fifaCodeFavCountry;
        private string _opponentTeam;
        private List<Match> _matches = null!;
        private List<Match> _matchesByFifaCode = null!;
        private FavCountryAndPlayers _favCountryAndPlayerSettings;

        private InitialFPSettings _initialFPSettings;
        private Gender _championship;
        private string _language = null!;
        private ScreenSize _screenSize;

        public DataManager()
        {
            if (_repository == null)
            {
                Initialize();
            }
        }

        public static void Initialize()
        {
            var factory = new RepositoryFactory(_httpClient);
            _repository = factory.CreateRepository();
        }

        public static IRepository GetRepository => _repository ?? throw new InvalidOperationException("Repository not initialized.");


        public List<Team> GetTeams() => _teams;
        public List<Result> GetResults() => _results;

        public List<Match> GetMatches() => _matches;
        public List<Match> GetMatchesOppTeam() => _matchesByFifaCode;

        public async Task SetTeams(Gender championship)
        {
            try
            {
                _teams = await _repository.GetAllTeams(championship);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to set teams for {championship}: {ex}");
            }
        }

        public async Task SetResults(Gender championship)
        {
            try
            {
                _results = await _repository.GetResults(championship);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to set results for {championship}: {ex}");
            }
        }


        public async Task SetMatches(Gender championship)
        {
            try
            {
                _matches = await _repository.GetAllMatches(championship);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to set matches for {championship}: {ex}");
            }
        }

        public async Task SetMatchesByFifaCode(Gender championship, string fifaCode)
        {

            try
            {
                _matchesByFifaCode = await _repository.GetMatchesByFifaCode(championship, fifaCode);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to set matches for chosen FIFA code: {ex}");
            }
        }

        // settings
        public async Task LoadSavedSettings()
        {
            await SetInitialSettings();
            await SetFavPlayerSettings();
        }

        private async Task SetInitialSettings()
        {
            _initialFPSettings = await _settingsRepository.GetInitialSettings();
            if (_initialFPSettings == null)
            {
                return;
            }
            _language = _initialFPSettings.Language;
            _championship = _initialFPSettings.Championship;
            _screenSize = _initialFPSettings.ScreenSize;
        }

        public async Task SaveInitialSettingsToRepo(InitialFPSettings settings)
        {
            await _settingsRepository.SaveInitialSettings(settings);
        }

        public async Task SetFavPlayerSettings()
        {
            _favCountryAndPlayerSettings = await _settingsRepository.GetFavPlayersSettings();
            if (_favCountryAndPlayerSettings == null)
            {
                return;
            }

            _fifaCodeFavCountry = _favCountryAndPlayerSettings.FifaCodeFavCountry;
            _opponentTeam = _favCountryAndPlayerSettings.OpponentTeam;
            _favPlayers = _favCountryAndPlayerSettings.FavPlayers;
            _notFavPlayers = _favCountryAndPlayerSettings.NotFavPlayers;
        }

        public async Task SaveFavPlayers(FavCountryAndPlayers favCountryAndPlayers)
        {
            await _settingsRepository.SaveFavPlayersSettings(favCountryAndPlayers);
        }

        public async Task ClearFavoritePlayersSettings()
        {
            try
            {
                await _settingsRepository.ClearFavPlayersSettings();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to clear favorite players settings: {ex.Message}", ex);
            }
        }

        public List<Player> GetFavPlayers() => _favPlayers;
        public List<Player> GetNotFavPlayers() => _notFavPlayers;
        public string GetFavFifaCode() => _fifaCodeFavCountry;
        public string GetOpponentFifaCode() => _opponentTeam;

        public string GetLanguage() => _language;
        public Gender GetChampionship() => _championship;
        public ScreenSize GetScreenSize() => _screenSize;
    }
}
