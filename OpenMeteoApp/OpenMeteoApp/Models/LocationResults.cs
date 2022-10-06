using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenMeteoApp.Models
{
    public class LocationResults
    {
        [JsonPropertyName("results")]
        public Location[] results{ get; set; }
    }
}
