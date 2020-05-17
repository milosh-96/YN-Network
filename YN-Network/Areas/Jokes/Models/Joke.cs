using System;
using Newtonsoft.Json;

namespace YN_Network.Areas.Jokes.Models
{
    public class Joke
    {
        [JsonProperty(PropertyName ="id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName ="type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName ="setup")]
        public string Setup { get; set; }

        [JsonProperty(PropertyName ="punchline")]
        public string PunchLine { get; set; }

       
    }

}