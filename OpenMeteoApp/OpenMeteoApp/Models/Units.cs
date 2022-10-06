using System.Text.Json.Serialization;

namespace OpenMeteoApp.Models
{
    public class Units
    {
        [JsonPropertyName("temperature_2m")]
        public string Temperature2M { get; set; }
    }
}