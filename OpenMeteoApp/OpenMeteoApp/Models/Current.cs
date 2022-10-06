using System;
using System.Text.Json.Serialization;

namespace OpenMeteoApp.Models
{
    public class Current
    {
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }
        [JsonPropertyName("weathercode")]
        public double Weathercode { get; set; }
        [JsonPropertyName("windspeed")]
        public double Windspeed { get; set; }
        [JsonPropertyName("winddirection")]
        public double Winddirection { get; set; }
    }
}