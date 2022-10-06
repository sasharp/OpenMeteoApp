using System;
using System.Text.Json.Serialization;

namespace OpenMeteoApp.Models
{
    public class Location
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }
}