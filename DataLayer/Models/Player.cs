using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Player
    {
        private static int _id = 1;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; } = null!;

        [JsonProperty("imagePath")]
        public string ImagePath { get; set; } = null!;

        [JsonProperty("goalsCount")]
        public int GoalsCount { get; set; } = 0;

        [JsonProperty("yellowCardCount")]
        public int YellowCardCount { get; set; } = 0;

        public Player()
        {
            Id = _id++;
        }

        public override bool Equals(object? obj)
        {
            return obj is Player player &&
                   Id == player.Id &&
                   Name == player.Name &&
                   ShirtNumber == player.ShirtNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, ShirtNumber);
        }
    }
}
