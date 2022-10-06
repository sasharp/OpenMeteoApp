using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenMeteoApp.Models
{
    public class Weather
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
        [JsonPropertyName("abbreviation")]
        public double Abbreviation { get; set; }
        [JsonPropertyName("generationtime_ms")]
        public double GenerationtimeMS { get; set; }
        [JsonPropertyName("utc_offset_seconds")]
        public int UTCOffsetSeconds { get; set; }
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
        [JsonPropertyName("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; }
        [JsonPropertyName("hourly")]
        public Hours Hourly { get; set; }
        [JsonPropertyName("hourly_units")]
        public Units HourlyUnits { get; set; }
        [JsonPropertyName("current_weather")]
        public Current CurrentWeather { get; set; }
    }
}
