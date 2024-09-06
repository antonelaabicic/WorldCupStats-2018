using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class PlayingTeam
    {
        [JsonProperty("country")]
        public string Country { get; set; } = null!;

        [JsonProperty("code")]
        public string Code { get; set; } = null!;

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }
    }
}