using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YN_Network.ViewModels
{
    public class LayoutViewModel
    {
        public Fact FactOfTheDay { get; set; }
        public string MyIp { get; set; }
        public LayoutViewModel()
        {
            var factJson = new WebClient().DownloadString("http://randomuselessfact.appspot.com/random.json?language=en'");
            this.FactOfTheDay = JsonSerializer.Deserialize<Fact>(factJson);

            var myIpJson = new WebClient().DownloadString("https://api.ipify.org/?format=json");
            this.MyIp = JsonSerializer.Deserialize<MyIpAddress>(myIpJson).Ip;


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

    public class MyIpAddress
    {
        [JsonPropertyName("ip")]
        public string Ip { get; set; }
    }
}



