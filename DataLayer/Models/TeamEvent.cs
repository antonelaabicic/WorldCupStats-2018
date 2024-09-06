using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class TeamEvent
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type_of_event")]
        public string TypeOfEvent { get; set; } = null!;

        [JsonProperty("player")]
        public string Player { get; set; } = null!;

        [JsonProperty("time")]
        public string Time { get; set; } = null!;
    }
}