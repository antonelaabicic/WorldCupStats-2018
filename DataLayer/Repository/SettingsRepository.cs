using DataLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly string _initialSettingsFilePath;
        private readonly string _favoritesSettingsFilePath;

        public SettingsRepository()
        {
            string baseFolderPath = "../../../../DataLayer/settingsFiles";

            _initialSettingsFilePath = Path.Combine(baseFolderPath, "initial_fp_settings.json");
            _favoritesSettingsFilePath = Path.Combine(baseFolderPath, "fav_fp_settings.json");

            CreateFileIfNotExist(_initialSettingsFilePath);
            CreateFileIfNotExist(_favoritesSettingsFilePath);
        }

        private void CreateFileIfNotExist(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating file {filePath}: {ex.Message}", ex);
            }
        }

        public async Task<InitialFPSettings> GetInitialSettings()
        {
            try
            {
                string json = await File.ReadAllTextAsync(_initialSettingsFilePath);
                InitialFPSettings? settings = JsonConvert.DeserializeObject<InitialFPSettings>(json);

                return settings;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading initial settings: {ex.Message}", ex);
            }
        }

        public async Task SaveInitialSettings(InitialFPSettings settings)
        {
            try
            {
                string json = JsonConvert.SerializeObject(settings);
                await File.WriteAllTextAsync(_initialSettingsFilePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving initial settings: {ex.Message}", ex);
            }
        }

        public async Task<FavCountryAndPlayers> GetFavPlayersSettings()
        {
            try
            {
                string json = await File.ReadAllTextAsync(_favoritesSettingsFilePath);
                FavCountryAndPlayers? settings = JsonConvert.DeserializeObject<FavCountryAndPlayers>(json);

                return settings;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading favorite players settings: {ex.Message}", ex);
            }
        }

        public async Task SaveFavPlayersSettings(FavCountryAndPlayers favCountryAndPlayers)
        {
            try
            {
                string json = JsonConvert.SerializeObject(favCountryAndPlayers);
                await File.WriteAllTextAsync(_favoritesSettingsFilePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving favorite players settings: {ex.Message}", ex);
            }
        }

        public async Task ClearFavPlayersSettings()
        {
            try
            {
                await File.WriteAllTextAsync(_favoritesSettingsFilePath, string.Empty);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error clearing favorite players settings: {ex.Message}", ex);
            }
        }
    }
}
