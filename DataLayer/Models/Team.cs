using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Team
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; } = null!;

        //[JsonProperty("alternate_name")]
        //public object AlternateName { get; set; } = null!;

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; } = null!;

        //[JsonProperty("group_id")]
        //public long GroupId { get; set; }

        //[JsonProperty("group_letter")]
        //public string GroupLetter { get; set; } = null!;

        public Team()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is Team team &&
                   Id == team.Id &&
                   Country == team.Country &&
                   FifaCode == team.FifaCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Country, FifaCode);
        }

        public override string? ToString()
        {
            return $"{Country} ({FifaCode})";
        }
    }
}
