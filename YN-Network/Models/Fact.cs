using System;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace YN_Network.Models
{
    public class Fact
    {
        private string text;

        [JsonPropertyName("text")]
        public string Text
        {
            get { return text; }
            set { if (value == null) { text = ""; } else { text = Regex.Replace(value, "<.*?>", String.Empty); } }
        }
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
