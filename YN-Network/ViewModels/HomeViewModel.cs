using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YN_Network.ViewModels
{
    public class HomeViewModel
    {
		public Fact FactOfTheDay { get; set; }

		public HomeViewModel()
        {
            var json = new WebClient().DownloadString("http://randomuselessfact.appspot.com/random.json?language=en'");
            this.FactOfTheDay = JsonSerializer.Deserialize<Fact>(json);
        }


    }



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


