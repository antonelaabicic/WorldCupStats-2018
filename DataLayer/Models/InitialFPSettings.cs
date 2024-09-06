using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class InitialFPSettings
    {
        [JsonProperty("Language")]
        public string Language { get; set; } = null!;

        [JsonProperty("Championship")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Championship { get; set; }

        [JsonProperty("ScreenSize")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ScreenSize ScreenSize { get; set; } 
    }
}
