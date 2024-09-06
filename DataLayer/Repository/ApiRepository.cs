using DataLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ApiRepository : IRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://worldcup-vua.nullbit.hr";

        public ApiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private string GetUrl(Gender gender, string endpoint)
        {
            string genderPath = gender.Equals(Gender.Women) ? "women" : "men";
            return $"{_baseUrl}/{genderPath}/{endpoint}";
        }

        private async Task<T> GetDataFromApi<T>(string url)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<T>(response) ?? throw new Exception($"Failed to deserialize JSON from {url}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching data from {url}: {ex.Message}");
            }
        }

        public async Task<List<Match>> GetAllMatches(Gender gender)
        {
            string url = GetUrl(gender, "matches");
            return await GetDataFromApi<List<Match>>(url);
        }

        public async Task<List<Team>> GetAllTeams(Gender gender)
        {
            string url = GetUrl(gender, "teams");
            return await GetDataFromApi<List<Team>>(url);
        }

        public async Task<List<Match>> GetMatchesByFifaCode(Gender gender, string fifaCode)
        {
            string url = $"{GetUrl(gender, "matches/country")}?fifa_code={fifaCode}";
            return await GetDataFromApi<List<Match>>(url);
        }

        public async Task<List<Result>> GetResults(Gender gender)
        {
            string url = GetUrl(gender, "teams/results");
            return await GetDataFromApi<List<Result>>(url);
        }
    }
}
