using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class TeamStatistics
    {
        [JsonProperty("starting_eleven")]
        public List<Player> StartingEleven { get; set; } = null!;

        [JsonProperty("substitutes")]
        public List<Player> Substitutes { get; set; } = null!;
    }
}