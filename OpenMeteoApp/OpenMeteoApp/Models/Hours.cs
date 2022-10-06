using System;
using System.Text.Json.Serialization;

namespace OpenMeteoApp.Models
{
    public class Hours
    {
        [JsonPropertyName("time")]
        public DateTime[] Time { get; set; }
        [JsonPropertyName("temperature_2m")]
        public double[] Temperature2M { get; set; }
        [JsonPropertyName("weathercode")]
        public double[] Weathercode { get; set; }
        [JsonPropertyName("windspeed_10m")]
        public double[] Windspeed10M { get; set; }
        [JsonPropertyName("winddirection_10m")]
        public double[] Winddirection10M { get; set; }
    }
}