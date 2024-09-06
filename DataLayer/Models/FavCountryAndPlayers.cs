using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class FavCountryAndPlayers
    {
        [JsonProperty("FifaCodeFavCountry")]
        public string FifaCodeFavCountry { get; set; } = null!;

        [JsonProperty("OpponentTeam")]
        public string OpponentTeam { get; set; } = null!;

        [JsonProperty("FavPlayers")]
        public List<Player> FavPlayers { get; set; } = null!;

        [JsonProperty("NotFavPlayers")]
        public List<Player> NotFavPlayers { get; set; } = null!;
    }
}
