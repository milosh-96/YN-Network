using System;
using System.Text.Json.Serialization;

namespace YN_Network.Models
{
    public class MyIpAddress
    {
        [JsonPropertyName("ip")]
        public string Ip { get; set; }
    }
}
