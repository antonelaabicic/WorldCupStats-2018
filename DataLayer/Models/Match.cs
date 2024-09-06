using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Match
    {
        [JsonProperty("venue")]
        public string Venue { get; set; } = null!;

        [JsonProperty("location")]
        public string Location { get; set; } = null!;

        [JsonProperty("attendance")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Attendance { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; } = null!;

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; } = null!;

        [JsonProperty("winner")]
        public string Winner { get; set; } = null!;

        [JsonProperty("winner_code")]
        public string WinnerCode { get; set; } = null!;

        [JsonProperty("home_team")]
        public PlayingTeam HomeTeam { get; set; } = null!;

        [JsonProperty("away_team")]
        public PlayingTeam AwayTeam { get; set; } = null!;

        [JsonProperty("home_team_events")]
        public List<TeamEvent> HomeTeamEvents { get; set; } = null!;

        [JsonProperty("away_team_events")]
        public List<TeamEvent> AwayTeamEvents { get; set; } = null!;

        [JsonProperty("home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; } = null!;

        [JsonProperty("away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; } = null!;
    }
}
