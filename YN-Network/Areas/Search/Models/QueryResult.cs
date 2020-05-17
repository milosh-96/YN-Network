using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace YN_Network.Areas.Search.Models
{
    public class QueryResult
    {
        [JsonProperty(PropertyName ="RelatedTopics")]
        public ICollection<Topic> RelatedTopics { get; set; } = new Collection<Topic>();
        public ICollection<Topic> Topics { get; set; } = new Collection<Topic>();


    }
}
