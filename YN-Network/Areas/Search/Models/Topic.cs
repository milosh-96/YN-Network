using System;
using Newtonsoft.Json;

namespace YN_Network.Areas.Search.Models
{
    public class Topic
    {
        [JsonProperty(PropertyName ="FirstURL")]
        public string FirstURL { get; set; }

        [JsonProperty(PropertyName ="Text")]
        public string Text { get; set; }
        public string Result { get; set; }
        public Icon Icon { get; set; } = new Icon();
        public Topic()
        {
        }
    }

    public class Icon
    {
        public string URL { get; set; }
    }
}
