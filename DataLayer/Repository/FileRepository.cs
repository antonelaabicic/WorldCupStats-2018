using DataLayer.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace DataLayer.Repository
{
    public class FileRepository : IRepository
    {
        public FileRepository()
        {
            CheckIfFileExists();
        }

        private static void CheckIfFileExists()
        {
            var genders = Enum.GetValues(typeof(Gender)) as Gender[] ?? throw new InvalidOperationException("Invalid gender values.");

            foreach (var gender in genders)
            {
                var matchesFilePath = GetFilePath(gender, "matches.json");
                var teamsFilePath = GetFilePath(gender, "teams.json");
                var resultsFilePath = GetFilePath(gender, "results.json");

                if (!File.Exists(matchesFilePath))
                {
                    throw new Exception($"{matchesFilePath} not found.");
                }

                if (!File.Exists(teamsFilePath))
                {
                    throw new Exception($"{teamsFilePath} not found.");
                }

                if (!File.Exists(resultsFilePath))
                {
                    throw new Exception($"{resultsFilePath} not found.");
                }
            }
        }

        private static string GetFilePath(Gender gender, string fileName)
        {
            string baseFolderPath = "../../../../DataLayer/jsonFiles";
            string folderPath = gender == Gender.Women ? Path.Combine(baseFolderPath, "women") : Path.Combine(baseFolderPath, "men");
            return Path.Combine(folderPath, fileName);
        }

        private static async Task<T?> ReadJsonFile<T>(string filePath) where T : class
        {
            try
            {
                string content = await File.ReadAllTextAsync(filePath);
                T? result = JsonConvert.DeserializeObject<T>(content) ?? throw new Exception($"Failed to deserialize JSON content from {filePath}");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading JSON file at {filePath}: {ex.Message}");
            }
        }

        public async Task<List<Match>> GetAllMatches(Gender gender)
        {
            string filePath = GetFilePath(gender, "matches.json");
            var allMatches = await ReadJsonFile<List<Match>>(filePath);
            return allMatches ?? new List<Match>();
        }

        public async Task<List<Match>> GetMatchesByFifaCode(Gender gender, string fifaCode)
        {
            string filePath = GetFilePath(gender, "matches.json");
            var allMatches = await ReadJsonFile<List<Match>>(filePath) ?? new List<Match>();

            return allMatches.Where(m => m.HomeTeam.Code == fifaCode || m.AwayTeam.Code == fifaCode).ToList();
        }

        public async Task<List<Team>> GetAllTeams(Gender gender)
        {
            string filePath = GetFilePath(gender, "teams.json");
            var teams = await ReadJsonFile<List<Team>>(filePath);
            return teams ?? new List<Team>();
        }

        public async Task<List<Result>> GetResults(Gender gender)
        {
            string filePath = GetFilePath(gender, "results.json");
            var results = await ReadJsonFile<List<Result>>(filePath);
            return results ?? new List<Result>();
        }
    }
}
