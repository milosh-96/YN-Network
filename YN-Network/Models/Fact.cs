using System;
using System.Text.Json.Serialization;

namespace YN_Network.Models
{
    public class Fact
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("source")]
        public string Source { get; set; }
        [JsonPropertyName("source_url")]
        public string SourceUrl { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
        [JsonPropertyName("permalink")]
        public string Permalink { get; set; }
    }
}
