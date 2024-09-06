using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class RepositoryFactory
    {
        private readonly HttpClient _httpClient;

        public RepositoryFactory(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IRepository CreateRepository()
        {
            var config = LoadConfig("../../../../DataLayer/settingsFiles/repository_config.json");

            if (config.UseFileRepository)
            {
                return new FileRepository();
            }
            else if (config.UseApiRepository)
            {
                return new ApiRepository(_httpClient);
            }
            else
            {
                throw new InvalidOperationException("Invalid repository configuration.");
            }
        }

        private static ConfigRepository LoadConfig(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                throw new Exception($"Configuration file not found: {configFilePath}");
            }

            try
            {
                var configContent = File.ReadAllText(configFilePath);
                var config = JsonConvert.DeserializeObject<ConfigRepository>(configContent) ?? throw new Exception("Failed to deserialize configuration.");

                return config;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error loading configuration file: {ex.Message}");
            }
        }

        public static ISettingsRepository GetSettings() => new SettingsRepository();
    }
}
